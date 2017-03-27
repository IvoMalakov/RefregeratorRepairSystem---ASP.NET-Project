namespace RefregeratorRepairSystem.Services
{
    using RefregeratorRepairSystem.Data;

    public abstract class Service
    {
        protected Service()
        {
            this.Context = Data.Context;
        }

        public RefregeratorRepairSystemContext Context { get; set; }
    }
}
