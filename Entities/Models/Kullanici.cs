using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string Rol { get; set; } // "Admin" veya "Kullanici"

        public ICollection<OduncVerilen> OduncKitaplar { get; set; }
    }
}
