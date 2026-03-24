using LoanAdvisor.Application.DTOs;
using LoanAdvisor.Application.Interfaces;
using LoanAdvisor.Domain.Entities;
using LoanAdvisor.Infrastructure.Repositories;

namespace LoanAdvisor.Application.Services;

public class LoanService : ILoanService
{
    private readonly IAIService _aiService;
    private readonly LoanRepository _repo;

    public LoanService(IAIService aiService, LoanRepository repo)
    {
        _aiService = aiService;
        _repo = repo;
    }

    public async Task<LoanResponseDto> AnalyzeLoanAsync(LoanRequestDto request)
    {
        var advice = await _aiService.GetLoanAdviceAsync(request);

        var entity = new LoanApplication
        {
            Name = request.Name,
            Income = request.Income,
            CreditScore = request.CreditScore,
            LoanAmount = request.LoanAmount,
            AIResponse = advice,
            CreatedDate = DateTime.UtcNow
        };

        await _repo.AddAsync(entity);

        return new LoanResponseDto
        {
            Message = advice
        };
    }

    public async Task<List<LoanApplication>> GetLoanHistoryAsync()
    {
        var loans = await _repo.GetAllAsync();
        return loans ?? new List<LoanApplication>(); // ✅ safety
    }

    public async Task<int> GetTotalApplicationsAsync()
    {
        return await _repo.GetTotalApplications();
    }

    public async Task<DashboardDto> GetDashboardAsync()
    {
        var loans = await _repo.GetAllAsync() ?? new List<LoanApplication>();

        return new DashboardDto
        {
            TotalLoans = loans.Count,
            ApprovedLoans = loans.Count(l => l.Status == "Approved"),
            RejectedLoans = loans.Count(l => l.Status == "Rejected"),
            AverageInterestRate = loans.Count > 0
                ? loans.Average(l => l.InterestRate)
                : 0
        };
    }
}