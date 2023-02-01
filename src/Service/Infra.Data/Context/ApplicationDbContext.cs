using Microsoft.EntityFrameworkCore;
using Service.Domain.Entities;

namespace Service.Infra.Data.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    public DbSet<RequestModel> Requests { get; set; }
    public DbSet<ResponseModel> Responses { get; set; }
    public DbSet<ExceptionModel> Exceptions { get; set; }
    public DbSet<LoggerModel> Logs { get; set; }
}