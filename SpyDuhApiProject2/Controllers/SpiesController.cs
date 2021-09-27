using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpyDuhApiProject2.DataAccess;
using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Controllers
{
    [Route("api/spies")]
    [ApiController]
    public class SpiesController : ControllerBase
    {
        SpyRepository _spyRepo;

        public SpiesController()
        {
            _spyRepo = new SpyRepository();
        }

        [HttpGet("{spyId}")]
        public IActionResult GetSpyById(Guid spyId)
        {
            var spy = _spyRepo.GetById(spyId);

            if (spy == null)
            {
                return NotFound($"No Spy with the id {spyId} was found.");
            }

            return Ok(spy);
        }

        [HttpGet]
        public IActionResult GetAllSpies()
        {
            return Ok(_spyRepo.GetAll());
        }

        [HttpPost]
        public IActionResult AddSpy(Spy newSpy)
        {
            if (string.IsNullOrEmpty(newSpy.Alias))
                return BadRequest("Alias is required");

            _spyRepo.Add(newSpy);

            return Created($"/api/spies/{newSpy.Id}", newSpy);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpy (Guid spyId, Spy spy)
        {
            var spyToUpdate = _spyRepo.GetById(spyId);

            if (spyToUpdate == null)
            {
                return NotFound($"Could not find spy with id of {spyId} to update");
            }

            var updatedBird = _spyRepo.Update(spyId, spy);

            return Ok(updatedBird);
        }
    }
}
