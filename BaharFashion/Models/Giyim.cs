using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaharFashion.Models
{
    public class Giyim
    {
        public int GiyimId { get; set; }
        public int TurId { get; set; }
        public int MarkaId { get; set; }
        public int KategoriId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string GiyimArtUrl { get; set; }
        public Tur Tur { get; set; }
        public Marka Marka { get; set; }
        public string Name { get; set; }
      
    }
}
