using BusTest.Models;
using BusTest.Repositories.Abstractions;
using BusTest.Services.Abstractions;

namespace BusTest.Services.Implementations;

public class UrlService
    : IUrlService
{
    public string GenerateToken()
    {
        return Guid.NewGuid().ToString().Substring(0,8);
    }
}