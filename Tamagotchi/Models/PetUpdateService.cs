// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using System;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using Tamagotchis.Models;

// public class PetUpdateService : BackgroundService
// {
//     private readonly IServiceScopeFactory _scopeFactory;

//     public PetUpdateService(IServiceScopeFactory scopeFactory)
//     {
//         _scopeFactory = scopeFactory;
//     }

//     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//     {
//         while (!stoppingToken.IsCancellationRequested)
//         {
//             using (var scope = _scopeFactory.CreateScope())
//             {
//                 var dbContext = scope.ServiceProvider.GetRequiredService<TamagotchiContext>();
//                 // Same logic as in CheckAndUpdatePets()
//                 var petsToUpdate = dbContext.Pets.Where(pet => pet.NeedsUpdate).ToList();
//                 foreach (var pet in petsToUpdate)
//                 {
//                   pet.IsHatched = true;
//                   pet.NeedsUpdate = false;
//                 }
//                 dbContext.SaveChanges();
//             }

//             await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
//         }
//     }
// }