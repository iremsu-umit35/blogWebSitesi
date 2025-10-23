using blogWebSitesi.Context;
using Microsoft.AspNetCore.Mvc;

namespace blogWebSitesi.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BlogDbContext _context;
        //veri tabanı bağlantısı alıp altadaki kodda çözüyor
        public BlogsController(BlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            // var blogs = _context.Blogs.ToList();
            //statusu 1 olanları istiyoruz
            var blogs = _context.Blogs.Where(x => x.Status == 1).ToList();
            return View(blogs);
        }

        // detail sayfası için read more a tıkladığımızda gelen id ye göre verileri getirme fonksiyonu details.htlm ile çalışıyor
        public IActionResult Details(int id)
        {
            var blog = _context.Blogs.Where(x => x.Id==id).FirstOrDefault();//veri tabanına bağlandı blogs tablosuna gitti ve tabloda nerede olduğunu dedi ve buldu ve birincisi döndü
            return View(blog);//ve verilerri viewe gönderdik
        }
    }
}
