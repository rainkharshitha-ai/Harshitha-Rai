namespace LoanAdvisor.Application.DTOs;

public class LoanRequestDto
{
    public string Name { get; set; } = string.Empty;
    public double Income { get; set; }
    public int CreditScore { get; set; }
    public double LoanAmount { get; set; }
}