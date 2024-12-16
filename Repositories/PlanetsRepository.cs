using Marvel.Data;
using Marvel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Repositories
{
    public class PlanetsRepository : IPlanetsRepository
    {
        private readonly MarvelContext _context;

        public PlanetsRepository(MarvelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Planet>> GetPlanets()
        {
            return await _context.Planets.ToListAsync();
        }

        public async Task<Planet> GetPlanetById(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return null;
            }
            return planet;
        }

        public async Task<Planet> PostPlanet(Planet planet)
        {
            _context.Planets.Add(planet);
            await _context.SaveChangesAsync();
            return planet;
        }

        public async Task<bool> PutPlanet(int id, Planet planet)
        {
            if (id != planet.Id)
            {
                return false;
            }

            _context.Entry(planet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeletePlanet(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return false;
            }

            _context.Planets.Remove(planet);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
