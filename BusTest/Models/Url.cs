using Microsoft.EntityFrameworkCore;

namespace BusTest.Models;

public class Url
{
    public int Id { get; set; }
    public string LongUrl { get; set; }
    public string Token { get; set; }
    public string ShortUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ActivationCount { get; set; }
    
}