using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface ICinemasService
    {
        Task<IEnumerable<Cinema>> GetAll();
        Cinema GetById(int Id);
        void Add(Cinema cinema);
        Cinema Update(int Id, Cinema newCinema);
        void Delete(int Id);
    }
}
