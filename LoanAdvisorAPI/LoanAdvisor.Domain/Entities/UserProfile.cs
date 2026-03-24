namespace LoanAdvisor.Domain.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Income { get; set; }
    public int CreditScore { get; set; }
}