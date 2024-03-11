
using ManagePeople.BLL.Interfaces;
using ManagePeople.BLL.Services;
using ManagePeople.DAL.Context;
using ManagePeople.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagePeople.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ManagePeopleContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<PersonServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
