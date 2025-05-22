using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OduncVerilen
    {
        public int Id { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime AlisTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; }
        public bool IadeEdildi { get; set; }
    }
}
