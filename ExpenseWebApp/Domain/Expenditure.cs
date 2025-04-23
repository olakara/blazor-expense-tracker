namespace ExpenseWebApp.Domain;

public class Expenditure
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Category { get; private set; }

    private Expenditure(Guid id, string description, decimal amount, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));
        
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        
        if (date > DateTime.Now)
            throw new ArgumentOutOfRangeException(nameof(date), "Date cannot be in the future.");
        
        Id = id;
        Description = description;
        Amount = amount;
        Date = date;
    }
        
    public static Expenditure CreateExpenditure(Guid id, string description, decimal amount, DateTime date)
    {
        return new Expenditure(id, description, amount, date);
    }
    
    public void UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));
        
        Description = description;
    }
    
    public void UpdateAmount(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        
        Amount = amount;
    }
}