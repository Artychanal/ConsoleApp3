using ConsoleApp3.solution.services.impl;
namespace ConsoleApp3.solution.services;

public interface IService <T>
{
    public void Save(T entity);
    public void Delete(long id);
    public T Get(long id);
    public List<T> GetAll();
    public List<T> GetAll(ClientService.SortField sortField, ClientService.SortOrder
        sortOrder);
    public List<T> FindAll(List<string> query);
}