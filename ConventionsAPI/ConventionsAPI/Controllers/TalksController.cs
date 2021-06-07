using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConventionsAPI.Auth;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConventionsAPI.Controllers
{
    [ApiController]
    [Route("Conventions/{conventionId}/[controller]")]
    public class TalksController : ControllerBase
    {
        private readonly ITalksRepository _talksRepository;

        public TalksController(ITalksRepository talksRepository)
        {
            _talksRepository = talksRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Talk>> Get(int conventionId)
        {
            var talks = _talksRepository.ListByConventionId(conventionId);
            return Ok(talks);
        }
        [Authorize(SystemRoles.Speaker)]
        [HttpPost]
        public ActionResult Create(Talk talk)
        {
            var res = _talksRepository.Create(talk);
            return Ok(res);
        }

        [Authorize]
        [HttpPost("reserve")]
        public ActionResult Reserve(Talk talk)
        {
            var res = _talksRepository.Reserve(talk);
            return Ok(res);
        }
    }
}
