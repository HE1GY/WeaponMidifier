namespace Decorator
{
    public abstract class DamagerModifier:IDamager
    {
        protected bool IsActive;
        public abstract DamagerStats Stats { get; set; }
        
        protected IDamager Damager { get; set; }
        protected IDamageable Damageable;


        protected DamagerModifier(IDamager damager)
        {
            Damager = damager;

            SubscribeOnRealWeapon(damager);
        }
        private void SubscribeOnRealWeapon(IDamager damager)
        {
            if (damager is Damager damagerWeapon)
            {
                damagerWeapon.AddedModifier += ActivatedCheck;
            }
        }

        public virtual void InflictDamage(IDamageable damageable)
        {
            Damageable = damageable;
        }

        public  void ActivatedCheck(DamagerModifier damagerModifier)
        {
            if (damagerModifier.Equals(this))
            {
                OnActivate();
            }
        }

        public void DeactivatedCheck(DamagerModifier damagerModifier)
        {
            if (damagerModifier.Equals(this))
            {
                OnDeactivate();
            }
        }



        protected abstract void Modify();

        protected virtual void OnActivate()
        {
            IsActive = true;
        }

        protected virtual void OnDeactivate()
        {
            IsActive = false;
        }

    }
}