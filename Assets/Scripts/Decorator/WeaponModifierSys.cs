using System.Collections.ObjectModel;
using UnityEngine;

namespace Decorator
{
    public class WeaponModifierSys:Damager
    {
        private void Start()
        {
            Stats = new DamagerStats(5);

            Enemy enemy = new Enemy();
            
            /*AddModifier(new PoisonModifier(this,5,1,2));
            InflictDamage(enemy);*/
            
            var damag = new DamageModifier(this, 100);
            var range = new RangeModifier(this, 2);
            var speed = new SpeedModifier(this, 5);

            AddModifier(damag);
            AddModifier(range);
            AddModifier(speed);


            print("Radius " + Stats.Radius);
            print("Speed " + Stats.Speed);
            InflictDamage(enemy);


            RemoveModifier(damag);
            RemoveModifier(range );
            RemoveModifier(speed );


            print("Radius " + Stats.Radius);
            print("Speed " + Stats.Speed);
            InflictDamage(enemy);
        }
    }

   


    public class Enemy : IDamageable
    {
        public void ReceiveDamage(int damage)
        {
            Debug.Log(damage);
        }
    }
}
