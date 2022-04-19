namespace OkOt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AkademisyenDersler",
                c => new
                    {
                        AkademisyenKod = c.Int(nullable: false),
                        DersKod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AkademisyenKod)
                .ForeignKey("dbo.Akademisyen", t => t.AkademisyenKod)
                .ForeignKey("dbo.Dersler", t => t.DersKod, cascadeDelete: true)
                .Index(t => t.AkademisyenKod)
                .Index(t => t.DersKod);
            
            CreateTable(
                "dbo.Akademisyen",
                c => new
                    {
                        PersonelKod = c.Int(nullable: false, identity: true),
                        PersonelAdi = c.String(),
                        PersonelSoyadi = c.String(),
                        PersonelBransi = c.String(),
                        PersonelBolum = c.Int(nullable: false),
                        PersonelTc = c.String(),
                    })
                .PrimaryKey(t => t.PersonelKod)
                .ForeignKey("dbo.Bolum", t => t.PersonelBolum, cascadeDelete: true)
                .Index(t => t.PersonelBolum);
            
            CreateTable(
                "dbo.Bolum",
                c => new
                    {
                        BolumKod = c.Int(nullable: false, identity: true),
                        BolumAdi = c.String(),
                        BolumKontenjan = c.Int(nullable: false),
                        BolumBaskan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BolumKod);
            
            CreateTable(
                "dbo.Dersler",
                c => new
                    {
                        DersKod = c.Int(nullable: false, identity: true),
                        DersAdi = c.String(),
                        DersTeorik = c.Byte(nullable: false),
                        DersUygulama = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.DersKod);
            
            CreateTable(
                "dbo.BolumBaskan",
                c => new
                    {
                        BolumKod = c.Int(nullable: false),
                        AkademisyenKod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BolumKod)
                .ForeignKey("dbo.Akademisyen", t => t.AkademisyenKod, cascadeDelete: true)
                .ForeignKey("dbo.Bolum", t => t.BolumKod)
                .Index(t => t.BolumKod)
                .Index(t => t.AkademisyenKod);
            
            CreateTable(
                "dbo.Notlar",
                c => new
                    {
                        DersKod = c.Int(nullable: false),
                        OgrenciNo = c.Int(nullable: false),
                        Vize = c.Int(nullable: false),
                        Final = c.Int(nullable: false),
                        Ddurum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DersKod)
                .ForeignKey("dbo.Dersler", t => t.DersKod)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciNo, cascadeDelete: true)
                .Index(t => t.DersKod)
                .Index(t => t.OgrenciNo);
            
            CreateTable(
                "dbo.Ogrenci",
                c => new
                    {
                        OgrenciId = c.Int(nullable: false, identity: true),
                        OgrenciAdi = c.String(),
                        OgrenciSoyadi = c.String(),
                        BolumOgrenci = c.Int(nullable: false),
                        OgrenciDogumTarihi = c.String(),
                        OgrenciAdres = c.String(),
                        OgrenciTc = c.String(),
                        OgrenciCinsiyet = c.String(),
                    })
                .PrimaryKey(t => t.OgrenciId)
                .ForeignKey("dbo.Bolum", t => t.BolumOgrenci, cascadeDelete: true)
                .Index(t => t.BolumOgrenci);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notlar", "OgrenciNo", "dbo.Ogrenci");
            DropForeignKey("dbo.Ogrenci", "BolumOgrenci", "dbo.Bolum");
            DropForeignKey("dbo.Notlar", "DersKod", "dbo.Dersler");
            DropForeignKey("dbo.BolumBaskan", "BolumKod", "dbo.Bolum");
            DropForeignKey("dbo.BolumBaskan", "AkademisyenKod", "dbo.Akademisyen");
            DropForeignKey("dbo.AkademisyenDersler", "DersKod", "dbo.Dersler");
            DropForeignKey("dbo.AkademisyenDersler", "AkademisyenKod", "dbo.Akademisyen");
            DropForeignKey("dbo.Akademisyen", "PersonelBolum", "dbo.Bolum");
            DropIndex("dbo.Ogrenci", new[] { "BolumOgrenci" });
            DropIndex("dbo.Notlar", new[] { "OgrenciNo" });
            DropIndex("dbo.Notlar", new[] { "DersKod" });
            DropIndex("dbo.BolumBaskan", new[] { "AkademisyenKod" });
            DropIndex("dbo.BolumBaskan", new[] { "BolumKod" });
            DropIndex("dbo.Akademisyen", new[] { "PersonelBolum" });
            DropIndex("dbo.AkademisyenDersler", new[] { "DersKod" });
            DropIndex("dbo.AkademisyenDersler", new[] { "AkademisyenKod" });
            DropTable("dbo.Ogrenci");
            DropTable("dbo.Notlar");
            DropTable("dbo.BolumBaskan");
            DropTable("dbo.Dersler");
            DropTable("dbo.Bolum");
            DropTable("dbo.Akademisyen");
            DropTable("dbo.AkademisyenDersler");
        }
    }
}
