using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    public abstract record BookDtoForManipulaton
    {

        [Required (ErrorMessage ="Title alanı boş geçilemez.")]
        [MinLength(2, ErrorMessage = "Title en az 2 karakter olacak.")]
        [MaxLength(1000, ErrorMessage = "Title en fazla 1000 karakter olacak.")]
        public String KitapAdi { get; init; }
        public string Yazar { get; init; }
        public string Yayinevi { get; init; }
        public int BasimYili { get; init; }
        public string ISBN { get; init; }

        public string OduncAlanKullanici { get; init; }
        public DateTime? OduncTarihi { get; init; }
        public DateTime? IadeTarihi { get; init; }
        public bool TeslimEdildiMi { get; init; }

        public DateTime EklenmeTarihi { get; init; } = DateTime.Now;
        //[Required(ErrorMessage = "Price alanı boş geçilemez.")]
        //[Range(10,1000)]
        //public decimal Price { get; init; }
    }
}
