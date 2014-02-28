using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using LightCore;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice
{
    public class ModuleLoader
    {
        readonly IContainerBuilder _builder;

        public ModuleLoader(IContainerBuilder builder)
        {
            _builder = builder;
        }

        public void LoadModules()
        {
            var binPath = /*Path.Combine(System.*/AppDomain.CurrentDomain.BaseDirectory/*, "bin")*/;
            foreach (var dll in Directory.GetFiles(binPath, "*.Module.*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    var assembly = Assembly.LoadFile(dll);
                    var types = assembly.GetLoadableTypes().Where(x => typeof(IRegisterModule).IsAssignableFrom(x));
                    foreach(var type in types)
                    {
                        var instance = Activator.CreateInstance(type) as IRegisterModule;
                        if(instance==null) continue;
                        instance.Register(_builder);
                    }
                    //var assembly = Assembly.LoadFile(dll);
                    //LoadAssembly(assembly);
                }
                catch (FileLoadException ex)
                {
                   System.Diagnostics.Debug.WriteLine("ModuleLoader, could not load assembly: " + ex);
                }
                catch (BadImageFormatException ex)
                {
                    System.Diagnostics.Debug.WriteLine("ModuleLoader, bad image assembly: " + ex);
                }
            }
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