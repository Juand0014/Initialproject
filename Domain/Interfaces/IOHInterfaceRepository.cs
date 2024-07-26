namespace Domain.Interfaces;

public interface IOHInterfaceRepository
{
    IQueryable<TResult> GetStoredProcedureResult<TResult>(string storeProcedureName, params string[] parameters);
}
