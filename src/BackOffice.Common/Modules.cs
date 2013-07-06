namespace Poseidon.BackOffice.Common
{
    public static class Modules
    {
        public static readonly int UmsPriority = 1;
        public static readonly string UmsModule = "UmsModule"; // User Management
        
        public static readonly int PmsPriority = 10;
        public static readonly string PmsModule = "PmsModule"; // Point Of Sale Management

        public static readonly int IcsPriority = 20;
        public static readonly string IcsModule = "IcsModule"; // Inventory Control Management
    }
}