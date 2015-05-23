using Pms.Business.Models;

namespace Pms.Business.Contracts
{
    /// <summary>
    /// Contract to register terminals to the system. 
    /// </summary>
    public interface IProvideTerminals
    {
        /// <summary>
        /// Register a terminal to the system.
        /// </summary>
        /// <param name="terminalId">The id of the terminal</param>
        /// <returns>A handle to the new terminal.</returns>
        PmsTerminal ClaimTerminal(uint terminalId);

        /// <summary>
        /// Unregister a terminal from the system
        /// </summary>
        /// <param name="terminal">The terminal to unregister</param>
        void FreeTerminal(PmsTerminal terminal);
    }
}