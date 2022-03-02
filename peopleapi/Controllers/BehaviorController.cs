using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace peopleapi.Controllers
{
    [Route("/behavior")]
    [ApiController]
    public class BehaviorController : ControllerBase
    {
        private readonly IBehaviorManager behaviorFactory;
        private readonly ILogger<BehaviorController> logger;

        public BehaviorController(IBehaviorManager behaviorFactory, ILogger<BehaviorController> logger) {
            this.logger = logger;
            this.behaviorFactory = behaviorFactory;
        }

        [HttpPost("{delayMilliseconds}")]
        public ActionResult<double> Post(int delayMilliseconds)
        {
            var asTimeSpan = TimeSpan.FromMilliseconds(delayMilliseconds);
            behaviorFactory.SetDelay(asTimeSpan);

            return Ok(asTimeSpan.TotalMilliseconds);
        }

        [HttpGet]
        public ActionResult Crash()
        {
            behaviorFactory.MakeCrash();
            return Ok();
        }
    }
}
