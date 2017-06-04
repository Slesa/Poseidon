namespace Devices
{
    public interface IDevice
    {
        string Name { get; }
        string Description { get; }

        void Start();
        void Stop();
    }
}