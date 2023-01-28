using Service.Domain.Interfaces;
using Service.Infra.Data.Context;

namespace Meempregarh.Infra.Data.Repositories;

public class RequestRepository : IRequestRepository
{
    private readonly ApplicationDbContext dbContext;

    public RequestRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    //public async Task<IEnumerable<User>> GetAllUsers()
    //{
    //    return await dbContext.Users
    //        .ToListAsync();
    //}

    //public async Task<User> GetUserByEmail(string email)
    //{
    //    return await dbContext.Users
    //        .Where(row => row.Email.Equals(email))
    //        .FirstOrDefaultAsync();
    //}

    //public async Task CreateUser(User user)
    //{
    //    dbContext.Add(user);
    //    await dbContext.SaveChangesAsync();
    //}
}
