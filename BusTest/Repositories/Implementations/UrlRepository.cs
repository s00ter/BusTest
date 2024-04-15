using BusTest.Models;
using BusTest.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BusTest.Repositories.Implimentations;

public class UrlRepository(
    ApplicationContext _context
    ) 
    : IUrlRepository
{
    public bool Add(Url url)
    {
        _context.Add(url);
        return Save();
    }

    public bool Update(Url url)
    {
        _context.Update(url);
        return Save();
    }

    public bool Delete(Url url)
    {
        _context.Remove(url);
        return Save();
    }

    public bool Save()
    {
        var res = _context.SaveChanges();
        return res > 0;
    }

    public async Task<List<Url>> GetAll()
    {
        var res = await _context.Urls.ToListAsync();
        return res;
    }
    
    public async Task<Url> GetByIdAsync(int id)
    {
        return await _context.Urls.FirstOrDefaultAsync(x => x.Id == id);
    }
}