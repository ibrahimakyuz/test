using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    //TODO:  internal public yap.
    public class Book
    {
        //TODO: WebAPI projemizdeki var olan Book class'ın propertileri buraya taşıyalım.
        //TODO: Sonra WebAPI projemizdeki var olan Models klasörünü silelim.
        //public int Id { get; set; }
        //public String Title { get; set; }
        //public decimal Price { get; set; }

        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public int BasimYili { get; set; }
        public string ISBN { get; set; }
        public string OduncAlanKullanici { get; set; }
        public DateTime? OduncTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; }
        public bool TeslimEdildiMi { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        public ICollection<OduncVerilen> OduncVerilenler { get; set; }

    }
}

