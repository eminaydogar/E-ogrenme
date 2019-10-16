using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Migrations
{
    [Migration(1)]
    public class _001_Users_and_Roles : Migration
    {
        public override void Down()
        {
            Delete.Table("Oylama");
            Delete.Table("KayıtTalep");
            Delete.Table("Pdf");
            Delete.Table("Bolum_Ogrenci_Dersler");
            Delete.Table("Bolum_Ogretmen_Dersler");
            Delete.Table("Kisiler");
            Delete.Table("Roles");
            Delete.Table("Dersler");
            Delete.Table("Bolum");
        }

        public override void Up()
        {
            Create.Table("Bolumler")
                .WithColumn("BolumID").AsString(32).PrimaryKey()
                .WithColumn("BolumAd").AsString(32);

            Create.Table("Dersler")
                 .WithColumn("DersId").AsInt32().Identity().PrimaryKey()
                 .WithColumn("Ders_Bolum").AsString(32).ForeignKey("Bolumler", "BolumID").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
                 .WithColumn("DersAd").AsString(50);

            Create.Table("Role")
                          .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                          .WithColumn("name").AsString(20);

            Create.Table("Kisiler")
                .WithColumn("Numara").AsInt32().PrimaryKey()
                .WithColumn("Ad").AsString(50)
                .WithColumn("Soyad").AsString(50)
                .WithColumn("Sifre").AsString(10)
                .WithColumn("Role").AsInt32().ForeignKey("Role", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
                 .WithColumn("Bolum").AsString(32).ForeignKey("Bolumler", "BolumID").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
                 .WithColumn("Email").AsString(32);



            Create.Table("Bolum_Ogretmen_Dersler")
                .WithColumn("bolum_ogretmen_dersID").AsInt32().Identity().PrimaryKey()
                .WithColumn("DersID").AsInt32().ForeignKey("Dersler", "DersId").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
                .WithColumn("Kullanıcı_Numara").AsInt32().ForeignKey("Kisiler", "Numara").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
                .WithColumn("Kullanıcı_Bolum").AsString().ForeignKey("Bolumler", "BolumID").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable();


            Create.Table("Bolum_Ogrenci_Dersler")
                .WithColumn("bolum_ogrenci_dersID").AsInt32().Identity().PrimaryKey()
                .WithColumn("DersID").AsInt32().ForeignKey("Dersler", "DersId").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
                .WithColumn("Kullanıcı_Numara").AsInt32().ForeignKey("Kisiler", "Numara").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
                .WithColumn("Kullanıcı_Bolum").AsString().ForeignKey("Bolumler", "BolumID").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable();
            Create.Table("Pdf")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Dosya_adı").AsString(32)
                .WithColumn("Dosya_konumu").AsString(128)
                .WithColumn("Ders_id").AsInt32().ForeignKey("Dersler", "DersId").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
                .WithColumn("Ogretmen_id").AsInt32().ForeignKey("Kisiler", "Numara").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable();
            Create.Table("KayıtTalep")
                .WithColumn("Talep_id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Ogrenci_id").AsInt32().ForeignKey("Kisiler", "Numara").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
             .WithColumn("Ogretmen_id").AsInt32().ForeignKey("Kisiler", "Numara").OnDeleteOrUpdate(System.Data.Rule.Cascade).NotNullable()
             .WithColumn("Ders_id").AsInt32().ForeignKey("Dersler", "DersId").OnDeleteOrUpdate(System.Data.Rule.Cascade);
            Create.Table("Oylama")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Ogretmen_id").AsInt32().ForeignKey("Kisiler", "Numara").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("Begenme").AsInt32()
                .WithColumn("Begenmeme").AsInt32();
            Create.Table("Ogrencioy")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Oylayan_id").AsInt32().ForeignKey("Kisiler", "Numara").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("Oylanan_id").AsInt32().ForeignKey("Kisiler", "Numara").OnDeleteOrUpdate(System.Data.Rule.Cascade);


        }
    }
}