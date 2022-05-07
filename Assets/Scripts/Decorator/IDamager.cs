namespace Decorator
{
    public interface IDamager
    {
        DamagerStats Stats { get; set; }
      
        void InflictDamage(IDamageable damageable);
    }
}