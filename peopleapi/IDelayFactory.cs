using System;
using System.Threading.Tasks;

namespace peopleapi {
    public interface IDelayFactory {
        void SetDelay(TimeSpan delay);

        Task Delay();
    }
}
