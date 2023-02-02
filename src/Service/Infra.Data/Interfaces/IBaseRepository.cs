namespace Service.Infra.Data.Interfaces;
internal interface IBaseRepository<TClass> where TClass : class
{
    Task Save(List<TClass> list);
}
