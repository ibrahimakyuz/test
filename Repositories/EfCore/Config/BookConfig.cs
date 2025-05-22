using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Config
{
    //TODO:IEntityTypeConfiguration dan kalıtım alıyoruz. Generic yapıda Book sınıfını alıyoruz.
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //TODO: Migrasyon işlemlerinde tabloda da veri yoksa çekirdek veriler ekleyeceğiz.
            //TODO: WebAPI projemizdeki var olan Repositories/Config/BookConfig class'ını  buraya taşıyalım. !!! !!! !!!
            builder.HasData(
                new Book { Id = 1, KitapAdi = "Karagöz ve Hacivat", Yazar = "ibrahim akyüz",
                Yayinevi ="deneme yayın evi",
                    BasimYili=2020,
                    ISBN= "1234567890",
                    OduncAlanKullanici = "Ali Veli",
                    OduncTarihi = DateTime.Now,
                    IadeTarihi = DateTime.Now.AddDays(10),
                    TeslimEdildiMi = true,
                    EklenmeTarihi = DateTime.Now
                },
               new Book
               {
                   Id = 2,
                   KitapAdi = "denem",
                   Yazar = "yazarımız",
                   Yayinevi = "test yayın evi",
                   BasimYili = 2000,
                   ISBN = "32143",
                   OduncAlanKullanici = "veli ali",
                   OduncTarihi = DateTime.Now,
                   IadeTarihi = DateTime.Now.AddDays(10),
                   TeslimEdildiMi = true,
                   EklenmeTarihi = DateTime.Now
               }
            );
        }
    }
}
