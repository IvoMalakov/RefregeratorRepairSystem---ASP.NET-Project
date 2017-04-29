namespace RefregeratorRepairSystem.Services
{
    using RefregeratorRepairSystem.Data;
    using RefregeratorRepairSystem.Services.Interfaces;

    public abstract class Service : IService
    {
        protected Service()
        {
            this.Context = Data.Context;
        }

        public RefregeratorRepairSystemContext Context { get; set; }
    }
}
