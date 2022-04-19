using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkOt.Models.Entities
{
    [Table("AkademisyenDersler")]
    public class AkademisyenDersler
    {
        [ForeignKey("Akademisyen")]
        [Key]
        public int AkademisyenKod { get; set; }
        [ForeignKey("Ders")]
        public int DersKod { get; set; }

        public Akademisyen Akademisyen { get; set; }
        public Dersler Ders { get; set; }
    }
}