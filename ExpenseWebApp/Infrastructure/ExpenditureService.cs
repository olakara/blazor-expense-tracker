﻿using ExpenseWebApp.DTO;
using ExpenseWebApp.Interfaces;

namespace ExpenseWebApp.Infrastructure;

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
    
    public async Task<ExpenditureDto> GetExpenditureById(Guid id)
    {
        var expense = await _api.GetExpenditureByIdAsync(id);
        return expense;
    }
}

