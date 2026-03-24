using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Dentcare.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Treatments()
        {
            return View();
        }

        public IActionResult Appointment(string treatment)
        {
            ViewBag.Treatment = treatment;
            return View();
        }

        public IActionResult CallClinic()
        {
            return View();
        }

        public IActionResult TimeSlots(string date)
        {
            ViewBag.SelectedDate = date;
            return View();
        }

        // SAVE APPOINTMENT
        [HttpPost]
        public IActionResult BookAppointment(string date, string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                ViewBag.Message = "Please select a time slot.";
                ViewBag.SelectedDate = date;
                return View("TimeSlots");
            }

            // get email from session
            string email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Signup");
            }

            using (SqlConnection con = new SqlConnection("Server=LAPTOP-KD0A4DEN\\SQLEXPRESS;Database=DentcareDB;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Appointments (PatientEmail, AppointmentDate, AppointmentTime) VALUES (@email,@date,@time)", con);

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@time", time);

                cmd.ExecuteNonQuery();
            }

            ViewBag.SelectedDate = date;
            ViewBag.Message = "Your appointment booking is successful for " + email + " on " + date + " at " + time;

            return View("TimeSlots");
        }

        public IActionResult Contact()
        {
            return View();
        }

        // GET Signup page
        public IActionResult Signup()
        {
            return View();
        }

        // SAVE PATIENT
        [HttpPost]
        public IActionResult Signup(string Email, string Password)
        {
            using (SqlConnection con = new SqlConnection("Server=LAPTOP-KD0A4DEN\\SQLEXPRESS;Database=DentcareDB;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Patients (Email, Password) VALUES (@Email,@Password)", con);

                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);

                cmd.ExecuteNonQuery();
            }

            // store signup email in session
            HttpContext.Session.SetString("UserEmail", Email);

            // redirect to appointment page
            return RedirectToAction("TimeSlots");
        }
    }
}