using blogWebSitesi.Context;
using blogWebSitesi.Models;
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
            var blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();//veri tabanına bağlandı blogs tablosuna gitti ve tabloda nerede olduğunu dedi ve buldu ve birincisi döndü
            blog.ViewCount += 1; // görüntüleme sayısını bir artırma işlemi
            _context.SaveChanges();
            var comment = _context.Comments.Where(x => x.BlogId == id).ToList(); //yorumları dödürüyor gönderilen idye göre
            ViewBag.Comments = comment.ToList();  //görüntü çantası oluşturdu 
            return View(blog);//ve verilerri viewe gönderdik
        }


        //veri tabanına veri göndermek istiyoruz post gönderme işelemi yapıcagız

        [HttpPost]
        public IActionResult CreateComment(Comment model)//gelen veriyi işliyoruz comment türünde model alıcaz
        {
            model.PublishDate = DateTime.Now;// şimdiki değeri al ve işlemi ata
            _context.Comments.Add(model);//veri tabanındaki comments tablosuna ekle

            // blog.CommentCount += 1;//yorum sayısını 1 artır
            var blog = _context.Blogs.Where(x => x.Id == model.Id).FirstOrDefault(); // contex ile veri tabanına bağlandı daha sonra blogs tablosuna gitti ve orada id si model.id ye eşit olanı buldu ve birincisini döndürdü
            blog.CommentCount += 1;//yorum sayısını 1 artır  



            _context.SaveChanges();//değişiklikleri kaydet
            return RedirectToAction("Details", new { id = model.BlogId });//yorumları yapanı detailse gönder ve göderilen mesajı anlık olarak gör
        }


        public IActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();

        }

        [HttpPost]// iletişim bilgilerini ve mesajı yollamak  için

        public IActionResult CreateContact(Contact model)
        {
            model.CreatedAt = DateTime.Now;//oluştruma tarihini ata burda atdığı zaman
            _context.Contacts.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");// contact sayfasına yönlendir

        }

        public IActionResult Support()
        {
            return View();
        }

    }
}
