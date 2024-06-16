using Blog.Presentation.Contexts;
using Blog.Presentation.Domain.Entities;
using Blog.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Presentation.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly BlogContext _context;
        private readonly IConfiguration _config;

        public AssignmentsController(IConfiguration config, BlogContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet]
        public IActionResult Assignments()
        {
            try
            {
                int legajo = _config.GetValue<int>("Legajo");
                IEnumerable<Assignment> assignments = _context.Assignments
                    .Where(a => a.Student.Legajo == legajo)
                    .Include(a => a.Class);

                if (!assignments.Any()) { throw new Exception(); }

                AssignmentsViewModel model = new AssignmentsViewModel(assignments);

                return View(model);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
