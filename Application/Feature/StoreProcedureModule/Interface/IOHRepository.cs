namespace Application.Features.StoreProcedureModule.Interface;

public interface IOHRepository
{
    IQueryable<TResult> GetStoredProcedureResult<TResult>(string storeProcedureName, params object[] parameters);
    void ExecuteProcedure(string storeProcedureName, params string[] parameters);
}

