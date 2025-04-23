using ExpenseWebApp.Domain;

namespace ExpenseWebApp.Services;

public class ExpenditureService
{
    public IEnumerable<Expenditure> GetExpenditures()
    {
        // Simulate fetching data from a database
        var expenditures = new List<Expenditure>
        {
            Expenditure.CreateExpenditure(Guid.NewGuid(), "Groceries", 150.00m, DateTime.Now.AddDays(-1)),
            Expenditure.CreateExpenditure(Guid.NewGuid(), "Utilities", 200.00m, DateTime.Now.AddDays(-2)),
            Expenditure.CreateExpenditure(Guid.NewGuid(), "Rent", 1200.00m, DateTime.Now.AddDays(-3))
        };

        return expenditures;
    }
}