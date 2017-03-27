namespace RefregeratorRepairSystem.Data
{
    public class Data
    {
        private static RefregeratorRepairSystemContext context;

        public static RefregeratorRepairSystemContext Context
            => context ?? (context = new RefregeratorRepairSystemContext());
    }
}
