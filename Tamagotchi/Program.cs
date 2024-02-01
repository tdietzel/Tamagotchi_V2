using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tamagotchis.Models;

namespace Tamagotchis
{
  class Program
  {
    static void Main(string[] args)
    {

      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();
      //builder.Services.AddHostedService<PetUpdateService>(); //ADDED THIS, it uses the PetUpdateService cs file under models


      builder.Services.AddDbContext<TamagotchiContext>(
        dbContextOptions => dbContextOptions
        .UseMySql(
          builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
          )
        )
      );

      WebApplication app = builder.Build();

      // app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Pets}/{action=Create}/{id?}"
      );

      app.Run();
    }
  }
}