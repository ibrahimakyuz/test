namespace Entities.DataTransferObjects
{
    //TODO : BookDto oluşturduk. Aynnı properylere sahip ama ileride ilişkisel veri tabaanı olacak şekilde düşünelim ..
    //[Serializable]
    public record BookDto //ctrl + .
    {
        //public int Id { get; init; }
        //public String Title { get; init; }
        //public decimal Price { get; init; }

        public int Id { get; init; }
        public string KitapAdi { get; init; }
        public string Yazar { get; init; }
        public string Yayinevi { get; init; }
        public int BasimYili { get; init; }
        public string ISBN { get; init; }

        public string OduncAlanKullanici { get; init; }
        public DateTime? OduncTarihi { get; init; }
        public DateTime? IadeTarihi { get; init; }
        public bool TeslimEdildiMi { get; init; }

        public DateTime EklenmeTarihi { get; init; } = DateTime.Now;
    }
}
