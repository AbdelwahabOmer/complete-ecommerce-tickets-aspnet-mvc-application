using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int Id)
        {
            var data = await _service.GetByIdAsync(Id);

            if (data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }


        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int Id)
        {
            var data = await _service.GetByIdAsync(Id);

            if (data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(Id, actor);
            return RedirectToAction(nameof(Index));
        }


        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _service.GetByIdAsync(Id);

            if (data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var data = await _service.GetByIdAsync(Id);

            if (data == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
