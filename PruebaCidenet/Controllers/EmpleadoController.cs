using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaCidenet.Data;
using PruebaCidenet.Models;

namespace PruebaCidenet.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly PruebaCidenetContext _context;

        public EmpleadoController(PruebaCidenetContext context)
        {
            _context = context;
        }

        // GET: Empleado
        public IActionResult Index()
        {
            IEnumerable<Empleado> emp = _context.Empleado.ToList();
            foreach(Empleado item in emp)
            {
                item.listaTipoIdentificacion = ArmarComboTipoIdentificacion();
                item.listaPaises = ArmarComboPaises();
                item.listaAreas = ArmarComboAreas();
            }
            return View(emp);
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/Create
        public IActionResult Create()
        {
            Empleado empleado = new Empleado();
            empleado.listaTipoIdentificacion = ArmarComboTipoIdentificacion();
            empleado.listaPaises = ArmarComboPaises();
            empleado.listaAreas = ArmarComboAreas();
            return View(empleado);
        }

        private SelectList ArmarComboTipoIdentificacion()
        {

            SelectListItem selListItem = new SelectListItem() { Value = "1", Text = "Cedula" };

            //Create a list of select list items - this will be returned as your select list
            List<SelectListItem> newList = new List<SelectListItem>();

            //Add select list item to list of selectlistitems
            newList.Add(selListItem);

            //selListItem.Value = "2";
            //selListItem.Text = "Tarjeta Identidad";
            SelectListItem selListItem1 = new SelectListItem() { Value = "2", Text = "Tarjeta Identidad" };
            newList.Add(selListItem1);

            //Return the list of selectlistitems as a selectlist
            return new SelectList(newList, "Value", "Text", null);

        }

        private SelectList ArmarComboPaises()
        {

            SelectListItem selListItem = new SelectListItem() { Value = "1", Text = "Colombia" };

            //Create a list of select list items - this will be returned as your select list
            List<SelectListItem> newList = new List<SelectListItem>();

            //Add select list item to list of selectlistitems
            newList.Add(selListItem);

            //selListItem.Value = "2";
            //selListItem.Text = "Estados Unidos";
            SelectListItem selListItem1 = new SelectListItem() { Value = "2", Text = "Estados Unidos" };
            newList.Add(selListItem1);

            //Return the list of selectlistitems as a selectlist
            return new SelectList(newList, "Value", "Text", null);

        }

        private SelectList ArmarComboAreas()
        {

            SelectListItem selListItem = new SelectListItem() { Value = "1", Text = "Talento Humano" };

            //Create a list of select list items - this will be returned as your select list
            List<SelectListItem> newList = new List<SelectListItem>();

            //Add select list item to list of selectlistitems
            newList.Add(selListItem);

            //selListItem.Value = "2";
            //selListItem.Text = "Sistemas";
            SelectListItem selListItem1 = new SelectListItem() { Value = "2", Text = "Sistemas" };
            newList.Add(selListItem1);

            //Return the list of selectlistitems as a selectlist
            return new SelectList(newList, "Value", "Text", null);

        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPais,IdTipoIdentificacion,NumIdentificacion,Nombre,PrimerApellido,OtrosNombres,SegundoApellido,CorreoElectronico,FechaIngreso,idArea,Estado,FechaRegistro")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            empleado.listaTipoIdentificacion = ArmarComboTipoIdentificacion();
            empleado.listaPaises = ArmarComboPaises();
            empleado.listaAreas = ArmarComboAreas();
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPais,IdTipoIdentificacion,NumIdentificacion,Nombre,PrimerApellido,OtrosNombres,SegundoApellido,CorreoElectronico,FechaIngreso,idArea,Estado,FechaRegistro")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.Id == id);
        }
    }
}
