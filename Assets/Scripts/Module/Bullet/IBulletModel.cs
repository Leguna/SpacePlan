using Agate.MVC.Base;

namespace SpacePlan.Module.Bullet
{
    public interface IBulletModel : IBaseModel
    {
        bool IsDeath { get; }
        float DamageValue { get; }
        float MaxHealth { get; }
    }
}