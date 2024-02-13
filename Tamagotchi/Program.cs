using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

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

      builder.Services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<TamagotchiContext>()
        .AddDefaultTokenProviders();

      WebApplication app = builder.Build();

      // app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication(); 
      app.UseAuthorization();

      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Index}"
      );

      app.Run();
    }
  }
}