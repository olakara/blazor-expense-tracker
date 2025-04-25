
using ExpenseWebApp.DTO;

namespace ExpenseWebApp.Interfaces;

public interface IExpenditureService
{
    Task<IEnumerable<ExpenditureDto>> GetExpenditures();
    
}