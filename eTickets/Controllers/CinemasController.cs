using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo", "Name", "Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Details/1
        public async Task<IActionResult> Details(int Id)
        {
            var data = await _service.GetByIdAsync(Id);

            if (data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }


        //Get: Cinemas/Edit/1
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
        public async Task<IActionResult> Edit(int Id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.UpdateAsync(Id, cinema);
            return RedirectToAction(nameof(Index));
        }


        //Get: Cinemas/Delete/1
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
