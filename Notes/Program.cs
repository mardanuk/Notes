using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.BusinessLogic;
using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Repository;

namespace Notes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connection = builder.Configuration.GetConnectionString("NoteDbConnection");

            // Add services to the container.
            builder.Services.AddDbContext<NotesContext>(options => options.UseNpgsql(connection));
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<INotesProceed, NotesProceed>();
            builder.Services.AddScoped<INotesRepository, NotesRepository>();
            builder.Services.AddScoped<IValidator<Note>, NoteValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.MapControllers();

            app.Run();
        }
    }
}