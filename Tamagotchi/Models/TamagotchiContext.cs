using Microsoft.EntityFrameworkCore;

namespace Tamagotchis.Models
{
  public class TamagotchiContext : DbContext
  {
    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Toy> Toys { get; set; }
    public DbSet<Food> Foods { get; set; }

    public TamagotchiContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Shop>()
        .HasData(
          new Shop { ShopId = 1 }
        );

      builder.Entity<Toy>()
        .HasData(
          new Toy { ToyId = 1, Name = "Ball", Excitement = 20, ItemType = "Toy", Quantity = 1, ShopId = 1, purchasedSuccessfully = false },
          new Toy { ToyId = 2, Name = "Bone", Excitement = 30, ItemType = "Toy", Quantity = 1, ShopId = 1, purchasedSuccessfully = false },
          new Toy { ToyId = 3, Name = "Frisbee", Excitement = 50, ItemType = "Toy", Quantity = 1, ShopId = 1, purchasedSuccessfully = false }
        );

      builder.Entity<Food>()
        .HasData(
          new Food { FoodId = 1, Name = "Kibble", Fullness = 10, ItemType = "Food", Quantity = 1, ShopId = 1, purchasedSuccessfully = false },
          new Food { FoodId = 2, Name = "Canned", Fullness = 20, ItemType = "Food", Quantity = 1, ShopId = 1, purchasedSuccessfully = false },
          new Food { FoodId = 3, Name = "Filet-Mignon", Fullness = 35, ItemType = "Food", Quantity = 1, ShopId = 1, purchasedSuccessfully = false }
        );
    }
  }
}
    // TOYSSS
    // public int ShopId { get; set; }
    // public int ToyId { get; set; }

    // public string Name { get; set; }
    // public int Excitement { get; set; }
    // public string ItemType { get; set; }
    // public int Quantity { get; set; }

    // public bool purchasedSuccessfully = false;
    // //   {"Ball", 20},
    // //   {"Bone", 30},
    // //   {"frisbee", 50}