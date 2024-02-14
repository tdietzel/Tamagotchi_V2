using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Tamagotchis.Models
{
  public class TamagotchiContext : IdentityDbContext<User>
  {
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Toy> Toys { get; set; }
    public DbSet<Food> Foods { get; set; }

    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<Inventory> Inventory { get; set; }

    public TamagotchiContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<Shop>()
        .HasData(
          new Shop { ShopId = 1 }
        );

      builder.Entity<User>()
      .HasOne(u => u.Inventory)
      .WithOne(i => i.User)
      .HasForeignKey<Inventory>(i => i.UserId);

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