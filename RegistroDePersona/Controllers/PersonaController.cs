using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistroDePersona.Models;
using RegistroDePersona.Models.ViewModels;

namespace RegistroDePersona.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            // Listado de mis elementos

            List<ListPersonaViewModel> lst;

            using (MelaniePruebaEntities db = new MelaniePruebaEntities())
            {
                lst = (from d in db.Personas
                       select new ListPersonaViewModel
                       {
                           ID = d.ID,
                           Nombre = d.Nombre,
                           FechaDeNacimiento = d.FechaDeNacimiento
                       }).ToList();
            }




            return View(lst);
        }

        //Ejecucion de guardado
        public ActionResult Nuevo()
        {

            return View();

        }

        //En caso de que haya un error

        [HttpPost]
        public ActionResult Nuevo(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MelaniePruebaEntities db = new MelaniePruebaEntities())
                    {
                        var oPersona = new Persona();
                        oPersona.Nombre = model.Nombre;
                        oPersona.FechaDeNacimiento = model.FechaDeNacimiento;

                        db.Personas.Add(oPersona);
                        db.SaveChanges();

                    }
                    return Redirect("~/Persona/");

                }

                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int ID)
        {
            PersonaViewModel model = new PersonaViewModel();

            using (MelaniePruebaEntities db = new MelaniePruebaEntities())
            {
                var oPersona = db.Personas.Find(ID);
                model.Nombre = oPersona.Nombre;
                model.FechaDeNacimiento = oPersona.FechaDeNacimiento;
                model.ID = oPersona.ID;
            }

            return View(model);

        }

        //Boton Editar

        [HttpPost]
        public ActionResult Editar(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MelaniePruebaEntities db = new MelaniePruebaEntities())
                    {
                        var oPersona = db.Personas.Find(model.ID);
                        oPersona.Nombre = model.Nombre;
                        oPersona.FechaDeNacimiento = model.FechaDeNacimiento;

                        db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Persona/");

                }

                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Boton Eliminar

        [HttpGet]


        public ActionResult Eliminar(int ID)
        {
            using (MelaniePruebaEntities db = new MelaniePruebaEntities())
            {

                var oPersona = db.Personas.Find(ID);
                db.Personas.Remove(oPersona);
                db.SaveChanges();
            }

            return Redirect("~/Persona/");

        }



    }
}