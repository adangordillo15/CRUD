using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCusers.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCusers.Controllers
{
    public class DirController : Controller
    {
        DirectionDataLayer objdirections = new DirectionDataLayer();
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Direccion> lstDir = new List<Direccion>();
            lstDir = objdirections.GetAllDirections().ToList();
            return View(lstDir);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                objdirections.AddDirection(direccion);
                return RedirectToAction("Index");
            }
            return View(direccion);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Direccion direccion = objdirections.GetDirectionData(id);

            if (direccion == null)
            {
                return NotFound();
            }
            return View(direccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Direccion direccion)
        {
            if (id != direccion.id_direccion)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objdirections.UpdateDirection(direccion);
                return RedirectToAction("Index");
            }
            return View(direccion);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Direccion direccion = objdirections.GetDirectionData(id);

            if (direccion == null)
            {
                return NotFound();
            }
            return View(direccion);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Direccion direccion = objdirections.GetDirectionData(id);

            if (direccion == null)
            {
                return NotFound();
            }
            return View(direccion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objdirections.DeleteDirection(id);
            return RedirectToAction("Index");
        }
    }
}
