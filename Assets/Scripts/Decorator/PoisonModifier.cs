namespace Decorator
{
    public  class PoisonModifier:OverTimeModifier
    {
        public sealed override DamagerStats Stats { get; set; }


        public PoisonModifier(IDamager damager, float duration, float ratePerSecond,int damage) : base(damager, duration, ratePerSecond)
        {
            Stats = new DamagerStats()
            {
                Damage = damage
            };
        }

        protected override void ModifyInflictOverTime()
        {
            Damageable.ReceiveDamage(Stats.Damage);
        }
    }
}