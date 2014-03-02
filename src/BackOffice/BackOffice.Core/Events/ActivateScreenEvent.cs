using System;

namespace Poseidon.BackOffice.Core.Events
{
    public class ActivateScreenEvent
    {
        public ActivateScreenEvent(Type screen)
        {
            ScreenType = screen;
        }

        public Type ScreenType { get; set; }
    }
}