using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IProducersService
    {
        Task<IEnumerable<Producer>> GetAllAsync();
        Task<Producer> GetByIdAsync(int Id);
        Task AddAsync(Producer producer);
        Task<Producer> UpdateAsync(int Id, Producer newProducer);
        Task DeleteAsync(int Id);
    }
}
