using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface ICinemasService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int Id);
        Task AddAsync(Cinema cinema);
        Task<Cinema> UpdateAsync(int Id, Cinema newCinema);
        Task DeleteAsync(int Id);
    }
}
