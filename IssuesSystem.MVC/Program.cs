using IssuesSystem.BL;
using IssuesSystem.DAL.Context;
using IssuesSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IssuesSystem.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //var connectionString = "Server=.;Database=TicketsDb;Trusted_Connection=true;Encrypt=false;";
            var connectionString = builder.Configuration.GetConnectionString("tickets");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<IssuesContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>(); //To Register the (service: TicketsRepo) from the DAL to The
            builder.Services.AddScoped<ITicketsManager, TicketsManager>(); //To Register the (service: TicketsManager) from the BL to The MVC


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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