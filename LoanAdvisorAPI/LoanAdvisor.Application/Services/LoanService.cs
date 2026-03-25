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

        int score = request.CreditScore;

        string decision;
        if (score > 750) decision = "Low Risk - Approved";
        else if (score > 600) decision = "Medium Risk";
        else decision = "High Risk - Reject";

        double interestRate = score > 750 ? 7 :
                              score > 600 ? 10 : 15;

        var entity = new LoanApplication
        {
            Name = request.Name,
            Income = request.Income,
            CreditScore = request.CreditScore,
            LoanAmount = request.LoanAmount,
            AIResponse = advice,
            Status = decision,
            CreatedDate = DateTime.UtcNow,
            InterestRate = interestRate
        };

        await _repo.AddAsync(entity);

        return new LoanResponseDto
        {
            Message = advice,
            Decision = decision,
            InterestRate = interestRate
        };
    }

    public async Task<List<LoanApplication>> GetLoanHistoryAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<int> GetTotalApplicationsAsync()
    {
        return await _repo.GetTotalApplications();
    }

    public async Task<DashboardDto> GetDashboardAsync()
    {
        var loans = await _repo.GetAllAsync();

        return new DashboardDto
        {
            TotalLoans = loans.Count,
            ApprovedLoans = loans.Count(l => l.Status.Contains("Approved")),
            RejectedLoans = loans.Count(l => l.Status.Contains("Reject")),
            AverageInterestRate = loans.Count > 0
                ? loans.Average(l => l.InterestRate)
                : 0
        };
    }
}