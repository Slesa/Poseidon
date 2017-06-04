namespace Devices
{
    public interface IChanger : IDevice
    {
        long MaxAmount { get; }
        string CurrencyName { get; }

        long Change(long amount, string currency);
    }
}