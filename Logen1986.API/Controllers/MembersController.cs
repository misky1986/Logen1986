using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Logen1986.API.Models;
using Logen1986.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logen1986.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Members")]
    public class MembersController : Controller
    {
        IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            this._memberService = memberService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var member = _memberService.GetAll();
            if (member == null)
            {
                return BadRequest("Member is null");
            }
            return Ok(member);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var member = _memberService.GetById(id);
            if (member == null)
            {
                return BadRequest("Member is null");
            }
            return Ok(member);
        }
    }
}