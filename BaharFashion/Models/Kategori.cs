namespace BaharFashion.Models
{
    public class Kategori
    {
        public int TurId { get; set; }
        public int KategoriId { get; set; }
        public string Name { get; set; }
        public Tur Tur { get; set; }
    }
}
