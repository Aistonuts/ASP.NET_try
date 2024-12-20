﻿namespace Wizzarts.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Wizzarts.Data.Models;

    public class CardBlackManaSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BlackMana.Any())
            {
                return;
            }

            await dbContext.BlackMana.AddAsync(new BlackMana
            {
                Cost = 0,
            });

            await dbContext.BlackMana.AddAsync(new BlackMana
            {
                Cost = 1,
                ColorName = "Black",
                ImageUrl = "/images/mana/b.png",
            });

            await dbContext.BlackMana.AddAsync(new BlackMana
            {
                Cost = 2,
                ColorName = "Black",
                ImageUrl = "/images/mana/b.png",
            });

            await dbContext.BlackMana.AddAsync(new BlackMana
            {
                Cost = 3,
                ColorName = "Black",
                ImageUrl = "/images/mana/b.png",
            });

            await dbContext.BlackMana.AddAsync(new BlackMana
            {
                Cost = 4,
                ColorName = "Black",
                ImageUrl = "/images/mana/b.png",
            });

            await dbContext.BlackMana.AddAsync(new BlackMana
            {
                Cost = 5,
                ColorName = "Black",
                ImageUrl = "/images/mana/b.png",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
