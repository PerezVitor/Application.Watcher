using Service.Domain.Entities;
using Service.Infra.Data.Context;
using Service.Infra.Data.Interfaces;

namespace Service.Infra.Data.Repositories;
internal class LoggerRepository : ILoggerRepository
{
    private readonly ApplicationDbContext dbContext;
    public LoggerRepository(ApplicationDbContext dbContext) => this.dbContext = dbContext;
    public async Task Save(List<LoggerModel> log)
    {
        await dbContext.Logs.AddRangeAsync(log);
        await dbContext.SaveChangesAsync();
    }
}
