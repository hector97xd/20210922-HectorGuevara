using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFP.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFP.Controllers
{
    public class CitaController : Controller
    {
        private readonly CitaContext context;
        public CitaController()
        {
            context = new CitaContext();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cita ci)
        {
            if (ModelState.IsValid)
            {
                context.Add(ci);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var model = new Cita();
            var lsprod = context.GetAll().Where(x => x.Id == id);
            foreach (var p in lsprod)
            {
                model.FechaCita = p.FechaCita;
                model.Descripcion = p.Descripcion;
                model.Paciente = p.Paciente;
                model.Doctor = p.Doctor;

            }
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var model = new Cita();
            var lsprod = context.GetAll().Where(x => x.Id == id);
            foreach (var p in lsprod)
            {
                model.Id = p.Id;
                model.FechaCita = p.FechaCita;
                model.Descripcion = p.Descripcion;
                model.Paciente = p.Paciente;
                model.Doctor = p.Doctor;

            }
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Cita ci)
        {
            if (ModelState.IsValid)
            {
                context.Update(ci);
                return RedirectToAction(nameof(Index));
            }
            return View(ci);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = new Cita();
            var lsprod = context.GetAll().Where(x => x.Id == id);
            foreach (var p in lsprod)
            {
                model.Id = p.Id;
                model.FechaCita = p.FechaCita;
                model.Descripcion = p.Descripcion;
                model.Doctor = p.Doctor;
                model.Paciente = p.Paciente;

            }
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteRegitro(Cita cita)
        {
            context.Delete(cita.Id);
            return RedirectToAction(nameof(Index));

        }
    }
}
