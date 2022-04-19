using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkOt.Models.Entities
{
    [Table("Dersler")]
    public class Dersler
    {
        [Key]
        public int DersKod { get; set; }
        public string DersAdi { get; set; }
        public byte DersTeorik { get; set; }
        public byte DersUygulama { get; set; }
    }
}