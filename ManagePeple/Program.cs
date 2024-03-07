
using ManagePeople.BLL.Interfaces;
using ManagePeople.BLL.Services;
using ManagePeople.DAL.Context;
using ManagePeople.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagePeple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Cela me permet de créer une DB nommée 'ManagePeople.DB' en utilisant EF en fonction de mon DbContext 'ManagePeopleContext'
            builder.Services.AddDbContext<ManagePeopleContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<PersonServices>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
