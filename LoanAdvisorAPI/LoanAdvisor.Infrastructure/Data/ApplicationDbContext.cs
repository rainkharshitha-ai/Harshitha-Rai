using Microsoft.EntityFrameworkCore;
using LoanAdvisor.Domain.Entities;

namespace LoanAdvisor.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<LoanApplication> LoanApplications { get; set; }
}