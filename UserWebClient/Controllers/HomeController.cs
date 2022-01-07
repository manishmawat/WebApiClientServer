using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserWebClient.Models;

namespace UserWebClient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> IndexAsync()
    {
        ViewData["Message"] = "Hello from webfrontend";
        HttpClient httpClient = new HttpClient();
        var response = await httpClient.GetAsync("http://userwebserver/WeatherForecast");
        var jsonString = await response.Content.ReadAsStringAsync();
        var viewModel = JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonString);
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
