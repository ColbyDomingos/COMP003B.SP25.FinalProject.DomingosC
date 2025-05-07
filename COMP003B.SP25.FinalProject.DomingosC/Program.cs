// Author: Colby D.
// Course: COMP-003B: ASP.NET Core
// Instructor: Jonathan Rodrigo Cruz
// Purpose: Final project synthesizing MVC, Web API, EF Core, and middleware

using COMP003B.SP25.FinalProject.DomingosC.Data;
using COMP003B.SP25.FinalProject.DomingosC.Middleware;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.DomingosC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options => //builder for the database that connects the project with the database, duh
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Mechanic API V1");
                    options.RoutePrefix = "api-docs";
                });
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<RequestTimingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
