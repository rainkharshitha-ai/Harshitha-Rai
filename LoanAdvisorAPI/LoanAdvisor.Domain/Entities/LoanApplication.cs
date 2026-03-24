namespace LoanAdvisor.Domain.Entities;

public class LoanApplication
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Income { get; set; }
    public int CreditScore { get; set; }
    public double LoanAmount { get; set; }

    public string AIResponse { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Pending";
    public double InterestRate { get; set; } = 0;
}