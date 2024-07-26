using Application.Features.StoreProcedureModule.Interface;

namespace Application.Features.StoreProcedureModule.Handlers;

public class StoreProcedureHandlers : IStoreProcedureHandlers
{
    private readonly IOHRepository repository;

    public StoreProcedureHandlers(IOHRepository repository)
    {
        this.repository = repository;
    }

    
}
