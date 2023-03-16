using Microsoft.EntityFrameworkCore;
using TicketSystem.BL.Managers.Departments;
using TicketSystem.BL.Managers.Developers;
using TicketSystem.BL.Managers.Tickets;
using TicketSystem.DAL.Context;
using TicketSystem.DAL.Repos.DepartmentsRepo;
using TicketSystem.DAL.Repos.DevelopersRepo;
using TicketSystem.DAL.Repos.TicketsRepo;

namespace TicketSystem.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("TicketKey");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TicketContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ITicketsManager, TicketsManager>();
            builder.Services.AddScoped<IDevelopersManager, DevelopersManager>();
            builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();

            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();
            builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();

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