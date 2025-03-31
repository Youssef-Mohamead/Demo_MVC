using Demo.BusinessLogic.Services.DepartmentServices;
using Demo.BusinessLogic.Services.EmployeeServices;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Demo.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
               // options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
               // options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
           //builder.Services.AddScoped<DepartmentRepository>();
           builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
           builder.Services.AddScoped<IDepartmentService, DepartmentService>();
           
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
           builder.Services.AddScoped<IEmployeeServices, EmployeeService>();

            #endregion

            var app = builder.Build();

            
            #region Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
