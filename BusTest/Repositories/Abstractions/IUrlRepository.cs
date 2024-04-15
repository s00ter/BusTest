using BusTest.Models;

namespace BusTest.Repositories.Abstractions;

public interface IUrlRepository
{
    bool Add(Url url);
    bool Update(Url url);
    bool Delete(Url url);
    bool Save();
    Task <List<Url>> GetAll();
    Task<Url> GetByIdAsync(int id);
}