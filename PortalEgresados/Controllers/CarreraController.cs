using Microsoft.AspNetCore.Mvc;
using PortalEgresados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEgresados.Controllers
{
    //nombre corregido
    public class CarreraController : Controller
    {
        public itesrcne_egresadosContext Context { get; }

        public CarreraController(itesrcne_egresadosContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            var carreras = Context.Carreras.OrderBy(x => x.Nombre);
            return View(carreras);
        }

        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost()]
        public IActionResult Agregar(Carrera c)
        {
            if (string.IsNullOrWhiteSpace(c.Nombre))
            {
                ModelState.AddModelError("", "Agregue el nombre de la carrera");
            }
            else if (string.IsNullOrWhiteSpace(c.CorreoJefe))
            {
                ModelState.AddModelError("", "Agregue el correo del jefe de carrera");
            }
            else if (Context.Carreras.Any(x => x.Nombre == c.Nombre))
            {
                ModelState.AddModelError("", "La carrera ya fue creada");
            }
            return View();
        }
        public IActionResult Editar(int id)
        {
            var car = Context.Carreras.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }
        [HttpPost()]
        public IActionResult Editar(Carrera c)
        {
            var car = Context.Carreras.FirstOrDefault(x => x.Id == c.Id);
            if (car == null)
            {
                ModelState.AddModelError("", "La carrera no existe o ha sido eliminada");
            }
            else if (string.IsNullOrWhiteSpace(c.Nombre))
            {
                ModelState.AddModelError("", "Agregue una nueva Carrera");
            }
            else if (Context.Carreras.Any(x => x.Nombre == c.Nombre)
            {
                ModelState.AddModelError("", "Esta carrera ya existe");
            }
            else
            {
                car.Nombre = c.Nombre;
                Context.Update(car);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public IActionResult Eliminar(int id)
        {
            var car = Context.Carreras.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }
        [HttpPost()]
        //Falta el modelo, por ende puse un parametro para que no marcara error.
        public IActionResult Eliminar(Carrera c)
        {
            var car = Context.Carreras.FirstOrDefault(x => x.Id == c.Id);
            if (car == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Context.Remove(car);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
