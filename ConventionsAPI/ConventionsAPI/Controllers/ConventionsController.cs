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
    [Route("[controller]")]
    public class ConventionsController : ControllerBase
    {
        private readonly IConventionsRepository _conventionsRepository;

        public ConventionsController(IConventionsRepository conventionsRepository)
        {
            _conventionsRepository = conventionsRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Convention>> Get()
        {
            var conventions = _conventionsRepository.List();
            return Ok(conventions);
        }

        [Authorize(SystemRoles.Admin)]
        [HttpPost]
        public ActionResult<Convention> Create(Convention item)
        {
            var created = _conventionsRepository.Create(item);
            return Ok(created);
        }

        [Authorize(SystemRoles.Admin)]
        [HttpPut]
        public ActionResult Update(Convention item)
        {
            _conventionsRepository.Update(item);
            return Ok();
        }

        [Authorize(SystemRoles.Admin)]
        [HttpDelete]
        public ActionResult Delete(Convention item)
        {
            _conventionsRepository.Delete(item);
            return Ok();
        }
    }
}
