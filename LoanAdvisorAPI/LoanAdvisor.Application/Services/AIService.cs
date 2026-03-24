using LoanAdvisor.Application.DTOs;
using LoanAdvisor.Application.Interfaces;

namespace LoanAdvisor.Application.Services;

public class AIService : IAIService
{
    public async Task<string> GetLoanAdviceAsync(LoanRequestDto request)
    {
        // Simulated AI Logic

        if (request.CreditScore >= 750 && request.Income >= 50000)
        {
            return "✅ High approval chance. Recommend Personal Loan.";
        }

        if (request.CreditScore < 600)
        {
            return "❌ Low approval chance. Improve credit score.";
        }

        return "⚠️ Moderate approval. Consider reducing loan amount.";
    }
}