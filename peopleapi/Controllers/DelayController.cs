using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace peopleapi.Controllers
{
    [Route("/delay")]
    [ApiController]
    public class DelayController : ControllerBase
    {
        private readonly IDelayFactory delayGenerator;
        private readonly ILogger<DelayController> logger;

        public DelayController(IDelayFactory delayFactory, ILogger<DelayController> logger) {
            this.logger = logger;
            delayGenerator = delayFactory;
        }

        [HttpPost("{delayMilliseconds}")]
        public ActionResult<double> Post(int delayMilliseconds)
        {
            var asTimeSpan = TimeSpan.FromMilliseconds(delayMilliseconds);
            delayGenerator.SetDelay(asTimeSpan);

            return Ok(asTimeSpan.TotalMilliseconds);
        }
    }
}
