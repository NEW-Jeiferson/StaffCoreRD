using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffCoreRD.Data;
using StaffCoreRD.Models;

namespace StaffCoreRD.Controllers
{
    [Authorize] // requiere sesión iniciada para TODO el controlador
    public class StaffController : Controller
    {
        private readonly StaffDbContext _context;

        public StaffController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: /Staff
        public async Task<IActionResult> Index()
        {
            var personal = await _context.Personal
                .Where(s => s.Activo)
                .OrderBy(s => s.Nombre)
                .ToListAsync();

            return View(personal);
        }

        // GET: /Staff/Create
        [Authorize(Roles = "Administrador,RRHH")]
        public IActionResult Create()
        {
            return View(new Staff());
        }

        // POST: /Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,RRHH")]
        public async Task<IActionResult> Create(Staff staff)
        {
            if (!ModelState.IsValid)
                return View(staff);

            _context.Personal.Add(staff);
            await _context.SaveChangesAsync();

            TempData["Exito"] = "Empleado creado exitosamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}