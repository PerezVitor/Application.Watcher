using Service.Domain.Entities;
using Service.Infra.Data.Context;
using Service.Infra.Data.Interfaces;

namespace Meempregarh.Infra.Data.Repositories;
public class RequestRepository : IRequestRepository
{
    private readonly ApplicationDbContext dbContext;
    public RequestRepository(ApplicationDbContext dbContext) => this.dbContext = dbContext;
    public async Task Save(List<RequestModel> request)
    {
        await dbContext.Requests.AddRangeAsync(request);
        await dbContext.SaveChangesAsync();
    }
}
