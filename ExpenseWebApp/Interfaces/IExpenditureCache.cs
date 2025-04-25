using ExpenseWebApp.DTO;

namespace ExpenseWebApp.Interfaces;

public interface IExpenditureCache
{
    Task<ExpenditureDto> GetExpenditureById(Guid id);
}