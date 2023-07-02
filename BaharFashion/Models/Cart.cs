using System.ComponentModel.DataAnnotations;
using System;
namespace BaharFashion.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }//sen kimsin?
        public int GiyimId { get; set; }  //ne aldın 
        public int Count { get; set; }    //kaç tane aldın
        public DateTime DateCreated { get; set; } //ne zaman aldın
        public virtual Giyim Giyim { get; set; } //aldıklarının bilgileri
    }
}
