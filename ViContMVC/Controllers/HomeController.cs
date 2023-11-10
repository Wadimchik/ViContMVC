using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViContMVC.Models;

namespace ViContMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private int[] _arr1;
        private int[] _arr2;
        private int[] _arr3;
        public static int Tool_id = 0;
        public static int Plot_id = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Random rand = new Random();
            _arr1 = new int[20];
            _arr2 = new int[20];
            _arr3 = new int[20];
            for(int i=0;i < _arr1.Length; i++)
            {
                _arr1[i] = rand.Next(10);
                _arr2[i] = rand.Next(10);
                _arr3[i] = rand.Next(10);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewPlot()
        {
            //запрос к БД
            //Random rand = new Random();
            Plot_id++;
            return PartialView(new Plot(_arr1,_arr2,"plot_"+Plot_id.ToString()));
        }

        public async Task<IActionResult> AutoPlot(string id)
        {
            //Plot_id++;
            Console.WriteLine(id);
            return PartialView(new Plot(_arr1, _arr2, id));
        }
        public IActionResult Clock()
        {
            return PartialView(DateTime.Now);
        }

        public IActionResult NewWindow() //можно передавать аргументы чтобы создавать нужный инструмент 
        {
            Tool_id++;
            Plot_id++;
            ViewBag.Tool_id = "tool_" + Tool_id;
            ViewBag.Plot_id = "plot_" + Tool_id;
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public record Plot(int[] x, int[] y, string? id);
    }
}