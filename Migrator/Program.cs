using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notes.Repository;

namespace Migrator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("MigrationSettings.json")
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("NoteDbConnection");

            var optionBuilder = new DbContextOptionsBuilder<NotesContext>();
            optionBuilder.UseNpgsql(connectionString);

            var dataContext = new NotesContext(optionBuilder.Options);
            dataContext.Database.Migrate();
        }
    }
}