using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkOt.Models.Entities
{
    [Table("Ogrenci")]
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        [ForeignKey("Bolum")]
        public int BolumOgrenci { get; set; }
        public string OgrenciDogumTarihi { get; set; }
        public string OgrenciAdres { get; set; }
        public string OgrenciTc { get; set; }
        public string OgrenciCinsiyet { get; set; }
        public Bolum Bolum { get; set; }
    }
}