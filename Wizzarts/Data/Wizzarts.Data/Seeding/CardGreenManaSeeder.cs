﻿namespace Wizzarts.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Wizzarts.Data.Models;

    public class CardGreenManaSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.GreenMana.Any())
            {
                return;
            }

            await dbContext.GreenMana.AddAsync(new GreenMana
            {
                Cost = 0,
            });

            await dbContext.GreenMana.AddAsync(new GreenMana
            {
                Cost = 1,
                ColorName = "Green",
                ImageUrl = "/images/mana/g.png",
            });

            await dbContext.GreenMana.AddAsync(new GreenMana
            {
                Cost = 2,
                ColorName = "Green",
                ImageUrl = "/images/mana/g.png",
            });

            await dbContext.GreenMana.AddAsync(new GreenMana
            {
                Cost = 3,
                ColorName = "Green",
                ImageUrl = "/images/mana/g.png",
            });

            await dbContext.GreenMana.AddAsync(new GreenMana
            {
                Cost = 4,
                ColorName = "Green",
                ImageUrl = "/images/mana/g.png",
            });

            await dbContext.GreenMana.AddAsync(new GreenMana
            {
                Cost = 5,
                ColorName = "Green",
                ImageUrl = "/images/mana/g.png",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}