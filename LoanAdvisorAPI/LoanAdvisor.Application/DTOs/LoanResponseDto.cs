namespace LoanAdvisor.Application.DTOs;

public class LoanResponseDto
{
    public string Message { get; set; } = string.Empty;

    public string Decision { get; set; } = string.Empty;

    public double InterestRate { get; set; }

}