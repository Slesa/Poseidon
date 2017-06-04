namespace Devices
{
    public interface IBuzzer : IDevice
    {
        /// <summary>
        /// Liefert true, wenn der Buzzer die Frequenz ändern kann.
        /// </summary>
        bool CanFrequency { get; }
        /*!	\return Liefert TRUE, wenn der Buzzer die Lautst´┐¢ke ´┐¢dern kann.
            \brief Lautst´┐¢ke´┐¢derung m´┐¢lich?
            \sa setCapabilities
        */
        bool CanVolume { get; }

        void Beep();
        void Sound(int num, int pause);
    }

}