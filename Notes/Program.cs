using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.BusinessLogic;
using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Domain.Options;
using Notes.Repository;
using Presentation.Configurations;
using System;

namespace Notes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //конфигурация
            builder.Configuration.AddJsonFile("Configurations/Configuration.json");
            builder.Services.Configure<PageConfiguration>(
                builder.Configuration.GetSection("PageProperties"));

            string? connection = builder.Configuration.GetConnectionString("NoteDbConnectionWithoutDocker");

            builder.Services.AddDbContext<NotesContext>(options => options.UseNpgsql(connection));
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<INotesProceed, NotesProceed>();
            builder.Services.AddScoped<IUsersProceed, UsersProceed>();
            builder.Services.AddScoped<IAccessesProceed, AccessesProceed>();

            builder.Services.AddScoped<INotesRepository, NotesRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IAccessesRepository, AccessesRepository>();

            builder.Services.AddScoped<IValidator<Note>, NoteValidator>();
            builder.Services.AddScoped<IValidator<User>, UserValidator>();


            var app = builder.Build();

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