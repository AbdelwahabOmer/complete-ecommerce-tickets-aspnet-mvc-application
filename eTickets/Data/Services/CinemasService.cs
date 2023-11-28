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

        public void Add(Cinema cinema)
        {
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cinema>> GetAll()
        {
            var data = await _context.Cinemas.ToListAsync();
            return data;
        }

        public Cinema GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Cinema Update(int Id, Cinema newCinema)
        {
            throw new NotImplementedException();
        }
    }
}
