using Microsoft.EntityFrameworkCore;
//using Service.Domain.Entities;

namespace Service.Infra.Data.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    //public DbSet<R>? Users { get; set; }
}