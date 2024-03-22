using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Repository
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public NotesContext(DbContextOptions<NotesContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(e =>
            {
                e.HasKey(key => key.Header);

                e.Property(p=>p.Header).IsRequired();
                e.Property(p=>p.Header).HasMaxLength(50);
                e.Property(p=>p.Header).ValueGeneratedNever();
                
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(key => key.Id);

                e.Property(p => p.Id).IsRequired();
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.Name).HasMaxLength(50);

                e.HasMany(t => t.Notes)
                .WithMany(t => t.Users)
                .UsingEntity(t => t.ToTable("accesses"));
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
