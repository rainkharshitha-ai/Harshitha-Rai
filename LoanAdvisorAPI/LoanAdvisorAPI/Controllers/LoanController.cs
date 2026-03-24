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
}