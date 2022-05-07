namespace Decorator
{
    public struct DamagerStats
    {
        public DamagerStats(int damage=0, int speed=0, int radius=0)
        {
            Damage = damage;
            Speed = speed;
            Radius = radius;
        }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public int Radius { get; set; }


        public static DamagerStats operator +(DamagerStats innerDamagerStats,DamagerStats outerDamagerStats)
        {
            DamagerStats newDamagerStats = new DamagerStats()
            {
                Damage = innerDamagerStats.Damage + outerDamagerStats.Damage,
                Speed = innerDamagerStats.Speed + outerDamagerStats.Speed,
                Radius = innerDamagerStats.Radius + outerDamagerStats.Radius
            };
            return newDamagerStats;
        }
       
        public static DamagerStats operator -(DamagerStats innerDamagerStats,DamagerStats outerDamagerStats)
        {
            DamagerStats newDamagerStats = new DamagerStats()
            {
                Damage = innerDamagerStats.Damage - outerDamagerStats.Damage,
                Speed = innerDamagerStats.Speed - outerDamagerStats.Speed,
                Radius = innerDamagerStats.Radius -outerDamagerStats.Radius
            };
            return newDamagerStats;
        }
       
    }
}