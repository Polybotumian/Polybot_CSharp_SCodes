using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkOt.Models.Entities
{
    [Table("BolumBaskan")]
    public class BolumBaskan
    {
        [ForeignKey("Bolum")]
        [Key]
        public int BolumKod { get; set; }
        [ForeignKey("Akademisyen1")]
        public int AkademisyenKod { get; set; }
        public Bolum Bolum { get; set; }
        public Akademisyen Akademisyen1 { get; set; }
    }
}