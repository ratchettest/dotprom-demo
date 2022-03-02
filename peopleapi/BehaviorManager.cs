using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace peopleapi {
    internal class BehaviorManager : IBehaviorManager {
        private bool shouldCrash;

        public TimeSpan ConfiguredDelay { get; private set; }

        public void SetDelay(TimeSpan duration) {
            ConfiguredDelay = duration;
        }

        public void MakeCrash() {
            shouldCrash = true;
        }

        public async Task DoBehavior() {
            if (shouldCrash) {
                throw new HttpRequestException("I CRASHED");
            }

            await Task.Delay(ConfiguredDelay);
        }
    }
}
