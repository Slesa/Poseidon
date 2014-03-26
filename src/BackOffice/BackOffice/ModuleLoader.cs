using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Prism.Modularity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core;

namespace Poseidon.BackOffice
{
    public static class ModuleLoader
    {
        public static IEnumerable<ModuleInfo> CollectModules()
        {
            var binPath = /*Path.Combine(System.*/AppDomain.CurrentDomain.BaseDirectory/*, "bin")*/;
            foreach (var dll in Directory.GetFiles(binPath, "*.Module.*.dll", SearchOption.AllDirectories))
            {
                IEnumerable<Type> types = null;
                try
                {
                    var assembly = Assembly.LoadFile(dll);
                    types = assembly.GetLoadableTypes().Where(x => typeof(IRegisterModule).IsAssignableFrom(x));
                }
                catch (FileLoadException ex)
                {
                   System.Diagnostics.Debug.WriteLine("ModuleLoader, could not load assembly: " + ex);
                }
                catch (BadImageFormatException ex)
                {
                    System.Diagnostics.Debug.WriteLine("ModuleLoader, bad image assembly: " + ex);
                }
                if (types == null) continue;
                foreach (var type in types)
                {
                    var instance = Activator.CreateInstance(type) as IRegisterModule;
                    if (instance == null) continue;
                    yield return instance.GetModuleInfo();
                }
                //var assembly = Assembly.LoadFile(dll);
                //LoadAssembly(assembly);
            }

            var coreRegister = new RegisterCoreModule();
            yield return coreRegister.GetModuleInfo();
        }
    }

    public static class AssemblyExtension
    {
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}