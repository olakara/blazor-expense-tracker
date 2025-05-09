﻿using ExpenseWebApp.DTO;
using Refit;
namespace ExpenseWebApp.Infrastructure;

public interface IExpenditureAPI
{
   [Get("/expenditures")]
   Task<List<ExpenditureDto>> GetExpendituresAsync();
   
   [Get("/expenditures/{id}")]
   Task<ExpenditureDto> GetExpenditureByIdAsync(Guid id);
}