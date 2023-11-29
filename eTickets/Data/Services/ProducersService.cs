using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ProducersService : IProducersService
    {
        private readonly AppDbContext _context;
        public ProducersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var data = await _context.Producers.FirstOrDefaultAsync(n => n.Id == Id);
            _context.Producers.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var data = await _context.Producers.ToListAsync();
            return data;
        }

        public async Task<Producer> GetByIdAsync(int Id)
        {
            var data = await _context.Producers.FirstOrDefaultAsync(n => n.Id == Id);
            return data;
        }

        public async Task<Producer> UpdateAsync(int Id, Producer newProducer)
        {
            _context.Update(newProducer);
            await _context.SaveChangesAsync();
            return newProducer;
        }
    }
}
