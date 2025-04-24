
using ExpenseWebApp.DTO;

namespace ExpenseWebApp.Infrastructure;

public interface IExpenditureService
{
    Task<IEnumerable<ExpenditureDto>> GetExpenditures();
    Task<ExpenditureDto> GetExpenditureById(Guid id);
}