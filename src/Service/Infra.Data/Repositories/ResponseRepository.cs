using Service.Domain.Entities;
using Service.Infra.Data.Context;
using Service.Infra.Data.Interfaces;

namespace Service.Infra.Data.Repositories;
internal class ResponseRepository : IResponseRepository
{
    private readonly ApplicationDbContext dbContext;
    public ResponseRepository(ApplicationDbContext dbContext) => this.dbContext = dbContext;
    public async Task Save(List<ResponseModel> response)
    {
        await dbContext.AddRangeAsync(response);
        await dbContext.SaveChangesAsync();
    }
}
