using MediatR;
using System.Reflection;
using TechnicalTest.Business;
using TechnicalTest.DataAccess;
using TechnicalTest.Infraestructure;

namespace TechnicalTest.MVC.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddBusinessLayer();
        builder.Services.AddDataAccessLayer();
        builder.Services.AddInfraestructureLayer();
        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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
