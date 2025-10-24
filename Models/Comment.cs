namespace blogWebSitesi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; } // kaydedeceğimiz blogun id sini alarak kaydet yapacağız
        public DateTime PublishDate { get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
        public string message { get; set; }

    }
}
