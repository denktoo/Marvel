using System.Collections.Generic;
using Marvel.Models;

namespace Marvel.Repositories
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> PostMovie(Movie movie);
        Task<bool> PutMovie(int id, Movie movie);
        Task<bool> DeleteMovie(int id);
    }
}