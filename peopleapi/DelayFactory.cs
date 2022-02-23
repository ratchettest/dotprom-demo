using System;
using System.Threading.Tasks;

namespace peopleapi
{
    internal class DelayFactory : IDelayFactory {
        private TimeSpan delay;

        public void SetDelay(TimeSpan duration) {
            delay = duration;
        }

        public async Task Delay() {
            await Task.Delay(delay);
        }
    }
}
