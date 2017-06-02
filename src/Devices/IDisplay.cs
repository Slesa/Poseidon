namespace Devices
{
    public interface IDisplay : IDevice
    {
        void Clear();
        void Display(string text);
    }
}