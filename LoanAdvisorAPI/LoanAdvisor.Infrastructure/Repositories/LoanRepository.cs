using LoanAdvisor.Domain.Entities;
using LoanAdvisor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LoanAdvisor.Infrastructure.Repositories;

public class LoanRepository
{
    private readonly ApplicationDbContext _context;

    public LoanRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(LoanApplication loan)
    {
        await _context.LoanApplications.AddAsync(loan);
        await _context.SaveChangesAsync();
    }

   
    public async Task<List<LoanApplication>> GetAllAsync()
    {
        return await _context.LoanApplications.ToListAsync();
    }

    
    public async Task<int> GetTotalApplications()
    {
        return await _context.LoanApplications.CountAsync();
    }
}