using System;

namespace _11_Screens.Framework 
{
    [Flags]
    public enum MessageBoxOptions 
    {
        Ok = 2,
        Cancel = 4,
        Yes = 8,
        No = 16,

        OkCancel = Ok | Cancel,
        YesNo = Yes | No,
        YesNoCancel = Yes | No | Cancel
    }
}