using LoanAdvisor.Application.DTOs;
using LoanAdvisor.Domain.Entities;

namespace LoanAdvisor.Application.Interfaces;

public interface ILoanService
{
    Task<LoanResponseDto> AnalyzeLoanAsync(LoanRequestDto request);
    Task<List<LoanApplication>> GetLoanHistoryAsync();
    Task<int> GetTotalApplicationsAsync();
    Task<DashboardDto> GetDashboardAsync();
}