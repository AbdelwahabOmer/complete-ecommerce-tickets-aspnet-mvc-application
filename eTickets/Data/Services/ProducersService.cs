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

        public void Add(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producer>> GetAll()
        {
            var data = await _context.Producers.ToListAsync();
            return data;
        }

        public Producer GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Producer Update(int Id, Producer newProducer)
        {
            throw new NotImplementedException();
        }
    }
}
