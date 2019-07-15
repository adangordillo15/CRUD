using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCusers.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCusers.Controllers
{
    public class UserController : Controller
    {
        UserDataAccessLayer objusers = new UserDataAccessLayer();
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Usuario> lstUser = new List<Usuario>();
            lstUser = objusers.GetAllUsers().ToList();
            return View(lstUser);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                objusers.AddUser(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Usuario usuario = objusers.GetUserData(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Usuario usuario)
        {
            if (id != usuario.CP)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objusers.UpdateUser(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Usuario usuario = objusers.GetUserData(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Usuario usuario = objusers.GetUserData(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objusers.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
