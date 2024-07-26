using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Runtime.CompilerServices;
using System.Text;
using JsonGenerator.Application.Exceptions;
using Microsoft.Data.SqlClient;
using Domain.Interfaces;
using Application.Features.StoreProcedureModule.Interface;


namespace Persistence.Repositories;

public class OHRepository : IOHRepository
{
    private readonly OHInterfaceContext context;

    public OHRepository(OHInterfaceContext context)
    {
        this.context = context;
    }


    private (string, List<SqlParameter>) GetProcedureExecExpression
    (string storeProcedureName, params object[] parameters)
    {
        StringBuilder SPExecution = new StringBuilder();
        List<SqlParameter> sqlParameters = new();

        SPExecution.Append($"EXEC {storeProcedureName} ");

        int paramIndex = 1;
        parameters.ToList().ForEach(parameter =>
        {
            string paramIdentifier = $"param{paramIndex}";

            SPExecution.Append($"@{paramIdentifier}, ");
            sqlParameters.Add(new(paramIdentifier, parameter));
            paramIndex++;
        });

        SPExecution.Remove(SPExecution.Length - 2, 2);

        return (SPExecution.ToString(), sqlParameters);
    }

    public void ExecuteProcedure
    (string storeProcedureName, params string[] parameters)
    {
        if (string.IsNullOrWhiteSpace(storeProcedureName))
            throw new NullOrEmptySPException();

        FormattableString SP_ExecutionExpression;

        SP_ExecutionExpression = parameters.Length == 0 ?
            FormattableStringFactory.Create($"EXEC {storeProcedureName}") :
            $"EXEC {storeProcedureName} {GetStoreProcedureParameters(parameters).ToString()}";

        context.Database.ExecuteSql(SP_ExecutionExpression);
    }

    private StringBuilder GetStoreProcedureParameters(string[] parameters)
    {
        StringBuilder SP_Params = new();

        foreach (string parameter in parameters)
            SP_Params.Append($"{parameter}, ");

        SP_Params.Remove(SP_Params.Length - 2, 2);

        return SP_Params;
    }

    public IQueryable<TResult> GetStoredProcedureResult<TResult>(string storeProcedureName, params object[] parameters)
    {
        if (string.IsNullOrWhiteSpace(storeProcedureName))
            throw new NullOrEmptySPException();

        if (parameters.Length <= 0)
            return context.Database.SqlQueryRaw<TResult>("EXEC {0}", storeProcedureName);

        var procedureTuple = GetProcedureExecExpression(storeProcedureName, parameters);

        return context.Database
            .SqlQueryRaw<TResult>(procedureTuple.Item1, procedureTuple.Item2.ToArray());
    }
}
