using Application.Features.ActiveConfig.Dto;
using Application.Features.Constant;
using Application.Features.ExchangeRates.Dto;
using Application.Features.Payrolls.Dto;
using Application.Features.StoreProcedureModule.Interface;

namespace Application.Features.StoreProcedureModule.Handlers;

public class StoreProcedureHandlers : IStoreProcedureHandlers
{
    private readonly IOHRepository repository;

    public StoreProcedureHandlers(IOHRepository repository)
    {
        this.repository = repository;
    }

    public async Task<List<PayrollsDto>> Get()
    {
        var result = await Task.FromResult(repository.GetStoredProcedureResult<PayrollsDto>(STOREPROCEDURED.SAC_GET_PAYROLLS).ToList());
        return result;
    }

    public async Task<List<ExchangeRatesDto>> GetExchangeRates(DateTime from, DateTime to)
    {
        var result = await Task.FromResult(repository.GetStoredProcedureResult<ExchangeRatesDto>(STOREPROCEDURED.GET_ALL_EXCHANGE_RATES, from, to).ToList());
        return result;
    }

    public async Task<List<PayrollInformationDto>> GetPayrollInformation(DateTime from, DateTime to)
    {
        var result = await Task.FromResult(repository.GetStoredProcedureResult<PayrollInformationDto>(STOREPROCEDURED.SAC_GET_PAYROLL_INFO, from, to).ToList());
        return result;
    }

    public async Task<List<ActiveConfigDto>> GetActiveConfig(DateTime from, DateTime to)
    {
        var result = await Task.FromResult(repository.GetStoredProcedureResult<ActiveConfigDto>(STOREPROCEDURED.SAC_GET_ACTIVE_CONFIG, from, to).ToList());
        return result;
    }

    public async Task<List<PayrollBudgetDto>> GetPayrollBudgetResult(DateTime from, DateTime to)
    {
        var result = await Task.FromResult(repository.GetStoredProcedureResult<PayrollBudgetDto>(STOREPROCEDURED.SAC_GET_PAYROLL_BUDGET, from, to).ToList());
        return result;
    }

    public async Task<List<SacPayrollRolesDto>> GetSacPayrollRolesByAssociated(string user)
    {
        var result = await Task.FromResult(repository.GetStoredProcedureResult<SacPayrollRolesDto>(STOREPROCEDURED.SAC_GET_PAYROLL_ROLES_BY_ASSOCIATED, user).ToList());
        return result;
    }
}
