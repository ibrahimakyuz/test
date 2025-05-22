using Entities.Models;
using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<OduncVerilen> OduncVerilenler { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Opsiyonel: Fluent API ile detaylı yapılandırma yapılabilir.
    }
}