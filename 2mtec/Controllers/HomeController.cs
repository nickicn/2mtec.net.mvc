using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _2mtec.Models;
using System.Text.Json;

namespace _2mtec.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Aluno> alunos =[];
        using (StreamReader leitor = new("Data\\alunos.json"))
        {
            string dados = leitor.ReadToEnd();
            alunos = JsonSerializer.Deserialize<List<Aluno>>(dados);
        }
        return View(alunos);
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
