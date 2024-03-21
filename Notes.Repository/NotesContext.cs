using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Repository
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
