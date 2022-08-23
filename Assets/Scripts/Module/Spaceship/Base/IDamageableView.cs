namespace SpacePlan.Module.Spaceship.Base
{
    public interface IDamageableView
    {
        void OnHitEvent(IDoingDamage damage);
    }
}