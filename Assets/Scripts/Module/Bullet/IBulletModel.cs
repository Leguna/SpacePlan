using Agate.MVC.Base;

namespace SpacePlan.Module.Bullet
{
    public interface IBulletModel : IBaseModel
    {
        bool IsDeath { get; }
    }
}