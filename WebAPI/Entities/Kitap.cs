using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public int SayfaSayisi { get; set; }
        public int Stok { get; set; }

        public ICollection<OduncVerilen> OduncVerilenler { get; set; }
    }
}
