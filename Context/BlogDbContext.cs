using blogWebSitesi.Models;
using Microsoft.EntityFrameworkCore;

namespace blogWebSitesi.Context
{
    public class BlogDbContext: DbContext
    {
        //veri tabanı bağlantısı ile veri tabanı configine edicez
//
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-KFUILH28\\SQLEXPRESS02; database= BlogWebSitesi; Integrated Security= True; TrustServerCertificate= True");
        }

        // oluşturulan tablolar

        public DbSet<Blog>Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }    

    }
}
