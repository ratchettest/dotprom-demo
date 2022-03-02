using System;
using System.Threading.Tasks;

namespace peopleapi {
    public interface IBehaviorManager {
        TimeSpan ConfiguredDelay { get; }

        void SetDelay(TimeSpan delay);

        void MakeCrash();

        Task DoBehavior();
    }
}
