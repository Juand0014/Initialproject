
using Application.Features.ActiveConfig.Dto;
using Application.Features.ExchangeRates.Dto;
using Application.Features.Payrolls.Dto;

namespace Application.Features.StoreProcedureModule.Interface;

public interface IStoreProcedureHandlers
{
    Task<List<PayrollsDto>> Get();
    Task<List<ActiveConfigDto>> GetActiveConfig(DateTime from, DateTime to);
    Task<List<ExchangeRatesDto>> GetExchangeRates(DateTime from, DateTime To);
    Task<List<PayrollBudgetDto>> GetPayrollBudgetResult(DateTime from, DateTime to);
    Task<List<PayrollInformationDto>> GetPayrollInformation(DateTime from, DateTime to);
    Task<List<SacPayrollRolesDto>> GetSacPayrollRolesByAssociated(string user);
}
