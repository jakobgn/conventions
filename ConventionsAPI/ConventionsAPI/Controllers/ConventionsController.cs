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
    [Route("[controller]")]
    public class ConventionsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Copenhagen", "London"
        };

        private readonly ILogger<ConventionsController> _logger;

        public ConventionsController(ILogger<ConventionsController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Convention>> Get()
        {
            return Ok(Enumerable.Range(0, 2).Select(index => new Convention
            {
                Date = DateTime.Now.AddDays(index),
                Id = index + 1,
                Location = Summaries[index]
            })
            .ToArray());
        }

        [Authorize("Admin")]
        [HttpPost]
        public ActionResult<Convention> Create()
        {
            var result = new Convention()
            {
                Date = DateTime.Now,
                Id = 3,
                Location = "Paris"
            };
            return Ok(result);
        }

        [Authorize("Admin")]
        [HttpPut]
        public ActionResult Update(int conventionId)
        {
            return Ok();
        }

        [Authorize("Admin")]
        [HttpDelete]
        public ActionResult Delete(int conventionId)
        {
            return Ok(conventionId);
        }
    }
}
