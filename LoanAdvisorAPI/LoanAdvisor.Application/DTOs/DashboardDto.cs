namespace LoanAdvisor.Application.DTOs
{
    public class DashboardDto
    {
        public int TotalLoans { get; set; }
        public int ApprovedLoans { get; set; }
        public int RejectedLoans { get; set; }
        public double AverageInterestRate { get; set; }
    }
}