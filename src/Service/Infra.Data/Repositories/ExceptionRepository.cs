using Service.Domain.Entities;
using Service.Infra.Data.Context;
using Service.Infra.Data.Interfaces;

namespace Meempregarh.Infra.Data.Repositories;
public class ExceptionRepository : IExceptionRepository
{
    private readonly ApplicationDbContext dbContext;
    public ExceptionRepository(ApplicationDbContext dbContext) => this.dbContext = dbContext;
    public async Task Save(List<ExceptionModel> exception)
    {
        await dbContext.Exceptions.AddRangeAsync(exception);
        await dbContext.SaveChangesAsync();
    }
}
