using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lesson1.Data;
namespace Lesson1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Lesson1Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Lesson1Context") ?? throw new InvalidOperationException("Connection string 'Lesson1Context' not found.")));

            // Add services to the container.

            //builder.Services.AddTransient - every time
            //builder.Services.AddScoped    - every request
            //builder.Services.AddSingleton - always one
            
            builder.Services.AddSingleton<IStudentService, StudentService>();

            builder.Services.AddControllersWithViews();

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

            app.MapControllerRoute(pattern: "{controller=Student}/{action=GetStudents}/{id?}", name: "default");

            app.Run();
        }
    }
}
