using Microsoft.EntityFrameworkCore;
using Service.Domain.Entities;
using Service.Domain.Models;

namespace Service.Infra.Data.Context;
public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(AppOptionsStatic.ConnectionString);

    public DbSet<RequestModel> Requests { get; set; }
    public DbSet<ResponseModel> Responses { get; set; }
    public DbSet<ExceptionModel> Exceptions { get; set; }
    public DbSet<LoggerModel> Logs { get; set; }
}