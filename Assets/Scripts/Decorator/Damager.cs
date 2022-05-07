using System;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator
{
    public abstract class Damager:MonoBehaviour,IDamager
    {
        /// <summary>
        ///  On Adding Modifier
        /// </summary>
        public event Action<DamagerModifier> AddedModifier;
        /// <summary>
        /// On Removing Modifier
        /// </summary>
        public event Action<DamagerModifier> RemovedModifier;
        
        public DamagerStats Stats { get; set; }
        
        /// <summary>
        /// Interactive modifiers
        /// </summary>
        private List<DamagerModifier> Modifiers = new List<DamagerModifier>();
        
        
        protected void AddModifier(DamagerModifier damagerModifier)
        {
            AddedModifier?.Invoke(damagerModifier);
            Modifiers.Add(damagerModifier);
            RemovedModifier += damagerModifier.DeactivatedCheck;
            AddedModifier -= damagerModifier.ActivatedCheck;
        }
        
        
        protected void RemoveModifier(DamagerModifier damagerModifier)
        {
            RemovedModifier?.Invoke(damagerModifier);
            Modifiers.Remove(damagerModifier);
            
            AddedModifier+=damagerModifier.ActivatedCheck;
            RemovedModifier -= damagerModifier.DeactivatedCheck;
        }
        
        
        public virtual void InflictDamage(IDamageable damageable)
        {
            foreach (DamagerModifier modifier in Modifiers)
            {
                modifier.InflictDamage(damageable);
            }
            damageable.ReceiveDamage(Stats.Damage);
        }
    }
}