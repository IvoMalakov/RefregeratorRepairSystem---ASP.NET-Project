using RefregeratorRepairSystem.Data;

namespace RefregeratorRepairSystem.Services.Interfaces
{
    public interface IService
    {
        RefregeratorRepairSystemContext Context { get; set; }
    }
}