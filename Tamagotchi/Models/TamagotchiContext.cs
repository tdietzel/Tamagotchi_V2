using Microsoft.EntityFrameworkCore;

namespace Tamagotchis.Models
{
  public class TamagotchiContext : DbContext
  {
    public DbSet<Pet> Pets { get; set; }

    public TamagotchiContext(DbContextOptions options) : base(options) { }
  }
}