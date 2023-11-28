using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IProducersService
    {
        Task<IEnumerable<Producer>> GetAll();
        Producer GetById(int Id);
        void Add(Producer producer);
        Producer Update(int Id, Producer newProducer);
        void Delete(int Id);
    }
}
