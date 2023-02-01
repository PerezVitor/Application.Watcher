using Microsoft.EntityFrameworkCore;
using Service.Domain.Entities;
using Service.Domain.Interfaces;
using Service.Infra.Data.Context;

namespace Service.Application.LogApp;
internal class LogDbProcess
{
    private readonly ApplicationDbContext _context;
    public LogDbProcess(ApplicationDbContext context) => _context = context;

    internal static async Task Process<T>(List<T> list, DbSet<T> context) where T : class, IProcessamento
    {
        if (!list.Any())
            return;

        list.RemoveAll(row => row.IsExecuted);

        foreach (var item in list)
        {
            item.SetExecuted();
            item.InsertLog();
            await context.AddAsync(item);
        }
    }

    internal async Task Process(List<RequestModel> list) => await Process(list, _context.Requests);
    internal async Task Process(List<ResponseModel> list) => await Process(list, _context.Responses);
    internal async Task Process(List<ExceptionModel> list) => await Process(list, _context.Exceptions);
    internal async Task Process(List<LoggerModel> list) => await Process(list, _context.Logs);
    internal void SaveChanges() => _context.SaveChanges();
}
