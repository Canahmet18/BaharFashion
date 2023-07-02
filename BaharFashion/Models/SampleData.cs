

namespace BaharFashion.Models
{
    public class SampleData
    {
        private readonly BaharFashionEntities _context;

     
        public SampleData(BaharFashionEntities context)
        {
            _context = context;
        }


        public void AddTurs()
        {
            if (_context.Turs.ToList().Count == 0)
            {
                        
                var tur = new List<Tur>
                {
                new Tur { Name = "Kazak",Description="Kazak" },
                new Tur { Name = "Pantolon",Description="Pantolon" },
                new Tur { Name = "Gomlek",Description="Gomlek" },
                new Tur { Name = "Elbise",Description = "Elbise" },
                new Tur { Name = "Ayakkabı",Description = "Ayakkabı" },
                new Tur { Name = "Çanta",Description = "Çanta" }

            };

                foreach (var item in tur)
                {
                    _context.Turs.Add(item);
                }
                _context.SaveChanges();
            }


        }

        public void AddMarkas()
        {
            if (_context.Markas.ToList().Count == 0)
            {
                //ekleme
                var markas = new List<Marka>
            {
                new Marka { Name = "Mavi" },
                new Marka { Name = "Koton" },
                new Marka { Name = "Limon" },
                new Marka { Name = "Mango" },
                new Marka { Name = "Batik" },
                new Marka { Name = "Bershka" },
                new Marka { Name = "Nike" }


            };

                foreach (var item in markas)
                {
                    _context.Markas.Add(item);
                }
                _context.SaveChanges();

            }
        }

        public void AddGiyims()
        {
            if (_context.Markas.ToList().Count == 0)
            {
                //ekleme
                var giyims = new List<Giyim>
            {
                new Giyim { KategoriId = 7, Tur= _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mavi"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 7, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mavi"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 5, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Koton"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 5, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Koton"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 5, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Koton"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 4, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Limon"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 4, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Limon"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 4, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Limon"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 6, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Limon"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 6, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 6, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Pantolon"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 12, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 12, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 12, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 10, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 10, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 10, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 11, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 11, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 11, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Elbise"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Batik"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 1, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Bershka"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 1, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Bershka"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 1, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Bershka"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 3, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Bershka"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 3, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Bershka"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 3, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Bershka"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 2, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 2, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 2, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Kazak"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 9, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Gömlek"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 9, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Gömlek"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 9, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Gömlek"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 8, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Gömlek"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 8, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Gömlek"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Mango"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 8, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Gömlek"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "MavMangoi"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 18, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 18, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 18, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 16, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 16, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 16, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 17, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 17, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 17, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Çanta"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 14, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 14, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 14, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 15, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 15, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 15, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 13, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 13, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },
                new Giyim { KategoriId = 13, Tur = _context.Turs.FirstOrDefault (g => g.Name == "Ayakkabı"), Price = 8.99M, Marka = _context.Markas.FirstOrDefault (a => a.Name == "Nike"), GiyimArtUrl = "/Content/Images/placeholder.gif" },

            };

                foreach (var item in giyims)
                {
                    _context.Giyims.Add(item);
                }
                _context.SaveChanges();

            }
        }


    }
}