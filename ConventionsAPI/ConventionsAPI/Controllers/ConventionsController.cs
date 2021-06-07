using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ConventionsAPI.Controllers
{
    [AllowAnonymous]
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

        [HttpGet]
        public IEnumerable<Convention> Get()
        {
            return Enumerable.Range(0, 2).Select(index => new Convention
            {
                Date = DateTime.Now.AddDays(index),
                Id = index + 1,
                Location = Summaries[index]
            })
            .ToArray();
        }
    }
}
