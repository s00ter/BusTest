namespace BusTest.Dto;

public class UrlDto
{
    public string LongUrl { get; set; }
    public string Token { get; set; }
    public string ShortUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ActivationCount { get; set; }
}