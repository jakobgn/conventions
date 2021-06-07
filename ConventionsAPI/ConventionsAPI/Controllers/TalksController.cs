using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ConventionsAPI.Controllers
{
    [ApiController]
    [Route("Conventions/{conventionId}/[controller]")]
    public class TalksController : ControllerBase
    {
        private readonly ILogger<ConventionsController> _logger;

        public TalksController(ILogger<ConventionsController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Talk>> Get(int conventionId)
        {
            if (conventionId == 1)
            {
                return Ok(new List<Talk>()
                {
                    new Talk()
                    {
                        Id = 1,
                        Speaker = "Dan Abramov",
                        Topic = "Beyond React 16",
                        Description =
                            "React 16 was released several months ago. Even though this update was largely API-compatible, the rewritten internal engine included new long-requested features and opened the door for exciting future possibilities."
                    }
                });
            }

            return Ok(new List<Talk>()
            {
                new Talk()
                {
                    Id = 1,
                    Speaker = "Dan Abramov",
                    Topic = "Beyond React 16",
                    Description =
                        "React 16 was released several months ago. Even though this update was largely API-compatible, the rewritten internal engine included new long-requested features and opened the door for exciting future possibilities."
                },
                new Talk()
                {
                    Id = 2,
                    Speaker = "Simon Brown",
                    Topic = "Visualising software architecture with the C4 model",
                    Description =
                        "In Simon Brown's talk at AOTB 2019 he explores the visual communication of software architecture based upon a decade of Simon’s experiences working with software development teams large and small across the globe."
                }
            });
        }
        [Authorize("Speaker")]
        [HttpPost]
        public ActionResult Create(int conventionId)
        {
            return Ok(conventionId);
        }

        [Authorize]
        [HttpPost("{talkId}/reserve")]
        public ActionResult Reserve()
        {
            return Ok();
        }
    }
}
