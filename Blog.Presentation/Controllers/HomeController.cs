using Blog.Presentation.Contexts;
using Blog.Presentation.Domain.Entities;
using Blog.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blog.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //[HttpGet("{legajo}")]
        public IActionResult Home()
        {
            try
            {
                int legajo = _config.GetValue<int>("Legajo");
                Student student = _context.Students.Where(s => s.Legajo == legajo)
                    .Include(s => s.College)
                    .Include(s => s.InfoItems)
                    .FirstOrDefault()!;

                StudentViewModel model = new StudentViewModel(student);

                return View(model);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}