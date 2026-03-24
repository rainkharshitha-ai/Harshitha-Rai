using Microsoft.AspNetCore.Mvc;
using DentoWeb.Data;
using DentoWeb.Models;

namespace DentoWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("book")]
        public IActionResult BookAppointment(Appointment appointment)
        {
            appointment.Status = "Booked";

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return Ok("Appointment booked successfully");
        }
    }
}