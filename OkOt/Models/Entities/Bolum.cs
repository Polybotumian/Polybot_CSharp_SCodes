using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkOt.Models.Entities
{
    [Table("Bolum")]
    public class Bolum
    {
        [Key]
        public int BolumKod { get; set; }
        public string BolumAdi { get; set; }
        public int BolumKontenjan { get; set; }
        public int BolumBaskan { get; set; }
    }
}