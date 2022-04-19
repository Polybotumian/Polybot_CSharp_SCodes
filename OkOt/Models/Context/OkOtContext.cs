using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OkOt.Models.Entities;

namespace OkOt.Models.Context
{
    public class OkOtContext : DbContext
    {
        public DbSet<Dersler> Derslers { get; set; }
        public DbSet<Akademisyen> Akademisyens { get; set; }
        public DbSet<Bolum> Bolums { get; set; }
        public DbSet<BolumBaskan> BolumBaskans { get; set; }
        public DbSet<AkademisyenDersler> AkademisyenDerslers { get; set; }
        public DbSet<Notlar> Notlars { get; set; }
        public DbSet<Ogrenci> Ogrencis { get; set; }
    }
}