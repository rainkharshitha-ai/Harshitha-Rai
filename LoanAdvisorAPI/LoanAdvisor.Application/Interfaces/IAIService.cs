using LoanAdvisor.Application.DTOs;

namespace LoanAdvisor.Application.Interfaces;

public interface IAIService
{
    Task<string> GetLoanAdviceAsync(LoanRequestDto request);
}