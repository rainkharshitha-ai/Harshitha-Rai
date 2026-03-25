using Microsoft.AspNetCore.Mvc;
using LoanAdvisor.Application.DTOs;
using LoanAdvisor.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LoanAdvisor.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpPost("analyze")]
    public async Task<IActionResult> AnalyzeLoan([FromBody] LoanRequestDto request)
    {
        var result = await _loanService.AnalyzeLoanAsync(request);
        return Ok(result);
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var data = await _loanService.GetDashboardAsync();
        return Ok(data);
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var data = await _loanService.GetLoanHistoryAsync();
        return Ok(data);
    }

    [HttpGet("total")]
    public async Task<IActionResult> GetTotal()
    {
        var total = await _loanService.GetTotalApplicationsAsync();
        return Ok(new { TotalApplications = total });
    }

    [HttpGet("emi")]
    public IActionResult CalculateEMI(double amount, double rate, int months)
    {
        double r = rate / 12 / 100;

        double emi = (amount * r * Math.Pow(1 + r, months)) /
                     (Math.Pow(1 + r, months) - 1);

        return Ok(new { EMI = Math.Round(emi, 2) });
    }
}