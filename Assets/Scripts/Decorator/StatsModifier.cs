namespace Decorator
{
    public abstract  class StatsModifier:DamagerModifier
    {
        public override DamagerStats Stats { get; set; }

        protected StatsModifier(IDamager damager) : base(damager)
        {
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            Modify();
        }

        protected override void OnDeactivate()
        {
            base.OnDeactivate();
            UnModify();
        }


        protected override void Modify()
        {
            Damager.Stats += Stats;
        }

        /// <summary>
        /// Return to previous stats
        /// </summary>
        protected virtual void UnModify()
        {
            Damager.Stats -= Stats;
        }
    }

    public  class DamageModifier : StatsModifier
    {
        public DamageModifier(IDamager damager, int damage) : base(damager)
        {
            Stats = new DamagerStats(damage: damage);
        }
        
    }

    public class RangeModifier:StatsModifier
    {

        public RangeModifier(IDamager damager, int attackRadius) : base(damager)
        {
            Stats = new DamagerStats(radius: attackRadius);
        }
        
    }
    public class SpeedModifier:StatsModifier
    {
        public SpeedModifier(IDamager damager, int speed) : base(damager)
        {
            Stats = new DamagerStats(speed: speed);
        }

        
    }
}