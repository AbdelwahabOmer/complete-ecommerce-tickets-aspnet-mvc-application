using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int Id);
        void Add(Actor actor);
        Actor Update(int Id, Actor newActor);
        void Delete(int Id);
    }
}
