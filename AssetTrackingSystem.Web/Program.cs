using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.BLL.Repositories;
using AssetTrackingSystem.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddDbContext<MemoryDbContext>();
            //builder.Services.AddScoped<IAssetRepository, MockAssetRepository>();

            builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AssetConnection")));

            builder.Services.AddScoped<IAssetRepository, SQLAssetRepository>();
            builder.Services.AddScoped<IAssetTypeRepository, SQLAssetTypeRepository>();
            builder.Services.AddScoped<IManufacturerRepository, SQLManufacturerRepository>();
            builder.Services.AddScoped<IModelRepository, SQLModelRepository>();

            builder.Services.AddHttpClient<IEmployeeService, APIEmployeeService>(client =>
                client.BaseAddress = new Uri("https://localhost:7217/api/employees/"));

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
                pattern: "{controller=Assets}/{action=Index}/{id?}");

            app.Run();
        }
    }
}