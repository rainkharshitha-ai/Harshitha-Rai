namespace DentoWeb.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string DentistName { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string TimeSlot { get; set; }

        public string Status { get; set; }
    }
}