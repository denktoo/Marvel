﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Marvel.Data;
using Marvel.Models;
using Marvel.Repositories;

namespace Marvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly IPlanetsRepository _planetsRepository;

        public PlanetsController(IPlanetsRepository planetsRepository)
        {
            _planetsRepository = planetsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
            var planets = await _planetsRepository.GetPlanets();
            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> GetPlanet(int id)
        {
            var planet = await _planetsRepository.GetPlanetById(id);
            if (planet == null)
            {
                return NotFound();
            }
            return Ok(planet);
        }

        [HttpPost]
        public async Task<ActionResult<Planet>> PostPlanet(Planet planet)
        {
            var addedPlanet = await _planetsRepository.PostPlanet(planet);
            return CreatedAtAction(nameof(GetPlanet), new { id = addedPlanet.Id }, addedPlanet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanet(int id, Planet planet)
        {
            if (id != planet.Id)
            {
                return BadRequest();
            }

            var updateSuccessful = await _planetsRepository.PutPlanet(id, planet);

            if (!updateSuccessful)
            {
                if (!await _planetsRepository.GetPlanetById(id).ContinueWith(t => t.Result != null))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanet(int id)
        {
            var planet = await _planetsRepository.DeletePlanet(id);
            if (planet == null)
            {
                return NotFound($"Plane Id {id} not found.");
            }
            return NoContent();
        }
    }
}