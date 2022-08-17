using Agate.MVC.Base;

namespace SpacePlan.Module.Bullet.Model
{
    public interface IBulletModel : IBaseModel
    {
        bool IsDeath { get; }
    }
}