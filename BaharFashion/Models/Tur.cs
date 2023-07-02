namespace BaharFashion.Models
{
    public class Tur
    {
        public int TurId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public List<Giyim> Giyims { get; set; }
       
    }
}
