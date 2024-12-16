﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Marvel.Data;
using Marvel.Models;
using Marvel.Repositories;

namespace Marvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _moviesRepository.GetMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _moviesRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Character data is null.");
            }
            var addedMovie = await _moviesRepository.PostMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = addedMovie.Id }, addedMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            var updateSuccessful = await _moviesRepository.PutMovie(id, movie);

            if (!updateSuccessful)
            {
                if (!await _moviesRepository.GetMovieById(id).ContinueWith(t => t.Result != null))
                {
                    return NotFound();
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var deletionSuccessful = await _moviesRepository.DeleteMovie(id);
            if (!deletionSuccessful)
            {
                return NotFound($"Movie with Id = {id} not found");
            }

            return NoContent();
        }
    }
}