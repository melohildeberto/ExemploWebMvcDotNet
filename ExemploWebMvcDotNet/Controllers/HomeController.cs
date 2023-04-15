using ExemploWebMvcDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExemploWebMvcDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Minha Mensagem";
            
            Aluno a = new Aluno() { Id = 1, Cpf = "123", Nome = "Meu Nome" };
            ViewBag.Aluno = a;

            List<String> list = new List<String>() { "A", "B", "C", "D", "E" };
            
            ViewBag.Lista = list; 
            
            return View();
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
}