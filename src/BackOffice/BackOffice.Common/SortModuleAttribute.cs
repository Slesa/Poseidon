namespace Poseidon.BackOffice.Common
{
    /// <summary>
    /// Allows the order of module loading to be controlled.  Where dependencies
    /// allow, module loading order will be controlled by relative values of priority
    /// </summary>
    public class SortModuleAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="priority">the priority to assign</param>
        public SortModuleAttribute(int priority)
        {
            Priority = priority;
        }

        /// <summary>
        /// Gets or sets the priority of the module.
        /// </summary>
        /// <value>The priority of the module.</value>
        public int Priority { get; private set; }
    }
}