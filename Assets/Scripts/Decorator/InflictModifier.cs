namespace Decorator
{
    public abstract  class InflictModifier : DamagerModifier
    {
        protected InflictModifier(IDamager damager) : base(damager)
        {
            Damager = damager;
        }
        
        protected sealed override void Modify()
        {
            if (IsActive)
            {
                ModifyInflict();
            }
        }
        
        public override  void InflictDamage(IDamageable damageable)
        {
            Modify();
            base.InflictDamage(damageable);
        }
        

        protected abstract void ModifyInflict();
    }
}