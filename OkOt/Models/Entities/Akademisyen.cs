using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkOt.Models.Entities
{
    [Table("Akademisyen")]
    public class Akademisyen
    {
        [Key]
        public int PersonelKod { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string PersonelBransi { get; set; }
        [ForeignKey("Bolum")]
        public int PersonelBolum { get; set; }
        public string PersonelTc { get; set; }
        public Bolum Bolum { get; set; }
    }
}