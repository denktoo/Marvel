using System.Collections.Generic;
using Marvel.Models;

namespace Marvel.Repositories
{
    public interface IPlanetsRepository
    {
        Task<IEnumerable<Planet>> GetPlanets();
        Task<Planet> GetPlanetById(int id);
        Task<Planet> PostPlanet(Planet planet);
        Task<bool> PutPlanet(int id, Planet planet);
        Task<bool> DeletePlanet(int id);
    }
}