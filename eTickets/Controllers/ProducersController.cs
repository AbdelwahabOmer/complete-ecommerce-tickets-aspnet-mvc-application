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
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL", "FullName", "Bio")] Producer producer)
        {
            if(!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producers/Details/1
        public async Task<IActionResult> Details(int Id)
        {
            var data = await _service.GetByIdAsync(Id);

            if (data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }


        //Get: Producers/Edit/1
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
        public async Task<IActionResult> Edit(int Id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.UpdateAsync(Id, producer);
            return RedirectToAction(nameof(Index));
        }


        //Get: Producers/Delete/1
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
