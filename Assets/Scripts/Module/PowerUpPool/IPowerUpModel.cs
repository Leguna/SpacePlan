using Agate.MVC.Base;

namespace SpacePlan.Module.PowerUpPool
{
    public interface IPowerUpPoolModel : IBaseModel
    {
        float SpawnTime { get; }
    }
}