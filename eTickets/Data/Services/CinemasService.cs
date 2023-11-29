using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class CinemasService : ICinemasService
    {
        private readonly AppDbContext _context;
        public CinemasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var data = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id == Id);
            _context.Cinemas.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var data = await _context.Cinemas.ToListAsync();
            return data;
        }

        public async Task<Cinema> GetByIdAsync(int Id)
        {
            var data = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id == Id);
            return data;
        }

        public async Task<Cinema> UpdateAsync(int Id, Cinema newCinema)
        {
            _context.Update(newCinema);
            await _context.SaveChangesAsync();
            return newCinema;
        }
    }
}
