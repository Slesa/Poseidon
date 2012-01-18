using Caliburn.Micro;

namespace BackOffice.Shared.Events
{
    public class ActivateScreenEvent
    {
        public ActivateScreenEvent(IScreen screen)
        {
            Screen = screen;
        }

        public IScreen Screen { get; set; }
    }
}