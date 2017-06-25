using System;

namespace Devices.Test.Console
{
    public static class CommandReader
    {
        public static T? GetVerb<T>(string[] buffer) where T : struct
        {
            foreach (var str in buffer)
            {
                T result;
                if (Enum.TryParse(str, true, out result))
                    return result;
            }
            return null;
        }

    }
}