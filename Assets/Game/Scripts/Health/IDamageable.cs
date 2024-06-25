namespace Game.HealthSystem
{
    public interface IDamageable
    {
        void TakeDamage(float amount);

        void Construct(float startingHealth);
    }
}