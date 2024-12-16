using Marvel.Data;
using Marvel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly MarvelContext _context;

        public SeriesRepository(MarvelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Series>> GetSeries()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<Series> GetSeriesById(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return null;
            }
            return series;
        }

        public async Task<Series> PostSeries(Series series)
        {
            _context.Series.Add(series);
            await _context.SaveChangesAsync();
            return series;
        }

        public async Task<bool> PutSeries(int id, Series series)
        {
            if (id != series.Id)
            {
                return false;
            }

            _context.Entry(series).State = EntityState.Modified;

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

        public async Task<bool> DeleteSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return false;
            }

            _context.Series.Remove(series);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
