using System.Threading.Tasks;

namespace Decorator
{
    public abstract class OverTimeModifier : InflictModifier
    {
        private readonly float _duration;
        private readonly float _ratePerSecond;

        protected OverTimeModifier(IDamager damager, float duration,float ratePerSecond) :base(damager)
        {
            _duration = duration;
            _ratePerSecond = ratePerSecond;
        }

        protected override void ModifyInflict()
        {
            ModifyOverTime();
        }

        protected abstract void ModifyInflictOverTime();
        


        private async void ModifyOverTime()
        {
            for (int i = 0; i < _duration; i++)
            {
                await WaitSeconds(_ratePerSecond);
                ModifyInflictOverTime();
            }
        }

        private async Task WaitSeconds(float waitSeconds)
        {
            await Task.Delay((int)waitSeconds*1000);
        }
        
        
    }
}