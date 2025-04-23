using ExpenseWebApp.DTO;
using ExpenseWebApp.Infrastructure;


namespace ExpenseWebApp.Services;

public class ExpenditureService : IExpenditureService
{
    private readonly IExpenditureAPI _api;
    
    public ExpenditureService(IExpenditureAPI api)
    {
        _api = api;
    }
   
    public async Task<IEnumerable<ExpenditureDto>> GetExpenditures()
    {
        var expenditures = await _api.GetExpendituresAsync();
        return expenditures.OrderByDescending(x => x.Date);
    }
}

