using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF___ReservaTransporte.Models;
using static EF___ReservaTransporte.StrategyConcrets;

namespace EF___ReservaTransporte.Controllers
{
    public class ReservasController : Controller
    {
        private readonly EfReservaTransporteContext _context;
        

        public ReservasController(EfReservaTransporteContext context)
        {
            _context = context;    

        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var efReservaTransporteContext = _context.Reservas.Include(r => r.Conductor).Include(r => r.Vehiculo);
            return View(await efReservaTransporteContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Conductor)
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewBag.TransportOptions = new List<SelectListItem>
   {
                new SelectListItem { Value = "Car", Text = "Auto" },
                new SelectListItem { Value = "Bus", Text = "Bus" },
                new SelectListItem { Value = "Van", Text = "Van" }
    };

            ViewData["ConductorId"] = new SelectList(_context.Conductors, "ConductorId", "ConductorId");
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "VehiculoId");
            return View();
        }

        public IActionResult mostrarMessage() {
            TempData["SuccessMessage"] = "Reserva creada exitosamente.";
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaId,VehiculoId,ConductorId,FechaHora,UbicacionOrigen,UbicacionDestino,Confirmada,TransportType")] Reserva reserva)
        {
            ModelState.Remove("Vehiculo");

            ModelState.Remove("Conductor");
            
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                _context.SaveChanges();
                await _context.SaveChangesAsync();
                
                IStrategyReserva strategy = null;
                switch (reserva.TransportType) {
                    case "Car":
                        strategy = new CarTransport();
                        break;
                    case "Bus":
                        strategy = new BusTransport();
                        break;
                    case "Van":
                        strategy = new VanTransport();
                        break;
                }

                strategy?.Transport();


            TempData["SuccessMessage"] = "Reserva creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductors, "ConductorId", "ConductorId", reserva.ConductorId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "VehiculoId", reserva.VehiculoId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductors, "ConductorId", "ConductorId", reserva.ConductorId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "VehiculoId", reserva.VehiculoId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaId,VehiculoId,ConductorId,FechaHora,UbicacionOrigen,UbicacionDestino,Confirmada")] Reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return NotFound();
            }

            ModelState.Remove("Vehiculo");

            ModelState.Remove("Conductor");
            //ModelState.Remove("TransportType");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ReservaId))
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
            ViewData["ConductorId"] = new SelectList(_context.Conductors, "ConductorId", "ConductorId", reserva.ConductorId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "VehiculoId", reserva.VehiculoId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Conductor)
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.ReservaId == id);
        }
    }
}
