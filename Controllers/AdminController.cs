using blogWebSitesi.Context;
using Microsoft.AspNetCore.Mvc;

namespace blogWebSitesi.Controllers
{
    public class AdminController : Controller
    {
        /// veritabanı çözmesi
        /// 
        private readonly  BlogDbContext _context;

        public AdminController(BlogDbContext context)
        {
            _context = context;
        }
        // database işlemleri burda bitti


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blogs()
        {
            var blogs = _context.Blogs.ToList();// veritabanından blogları çek
            return View(blogs);// blogları view a gönder
        }
    }
}
