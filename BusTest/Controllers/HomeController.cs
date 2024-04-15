using System.Diagnostics;
using BusTest.Dto;
using Microsoft.AspNetCore.Mvc;
using BusTest.Models;
using BusTest.Repositories.Abstractions;
using BusTest.Repositories.Implimentations;
using BusTest.Services.Abstractions;

namespace BusTest.Controllers;

public class HomeController(
    IUrlRepository urlRepository,
    IUrlService urlService
    ) 
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var res = await urlRepository.GetAll();
        return View(res);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Url url)
    {
        url.Token = urlService.GenerateToken();
        url.ShortUrl = $"http://localhost:5000/{url.Token}";
        url.CreatedAt = DateTime.Now;
        urlRepository.Add(url);
        return RedirectToAction("Index");
    }
        
    public async Task Redirect(string token)
    {
        var urls = await urlRepository.GetAll();

        var url = urls.FirstOrDefault(x => x.Token == token);

        if (url != null)
        {
            HttpContext.Response.Redirect(url.LongUrl);
            
            url.ActivationCount++;
            urlRepository.Update(url);
        }
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var itemToDelete = await urlRepository.GetByIdAsync(id);

        urlRepository.Delete(itemToDelete);
        
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(int id, UrlDto urlDto)
    {
        var url = new Url
        {
            Id = id,
            LongUrl = urlDto.LongUrl,
            Token = urlDto.Token,
            ShortUrl = urlDto.ShortUrl,
            CreatedAt = urlDto.CreatedAt,
            ActivationCount = urlDto.ActivationCount,
        };
        
        urlRepository.Update(url);

        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var url = await urlRepository.GetByIdAsync(id);
        
        var urlVM = new UrlDto
        {
            LongUrl = url.LongUrl,
            Token = url.Token,
            ShortUrl = url.ShortUrl,
            CreatedAt = url.CreatedAt,
            ActivationCount = url.ActivationCount,
        };
        return View(urlVM);
    }
}