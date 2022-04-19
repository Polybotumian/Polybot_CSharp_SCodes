using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkOt.Models.Entities
{
    [Table("Notlar")]
    public class Notlar
    {
        [ForeignKey("Ogrenci")]
        public int OgrenciNo { get; set; }
        [ForeignKey("Ders")]
        [Key]
        public int DersKod { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        public int Ddurum { get; set; }

        public Ogrenci Ogrenci { get; set; }
        public Dersler Ders { get; set; }
    }
}