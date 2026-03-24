using Microsoft.AspNetCore.Mvc;
using DentoWeb.Data;
using DentoWeb.Models;

namespace DentoWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public IActionResult Signup(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return Ok("Signup successful");
        }
    }
}