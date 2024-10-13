﻿namespace Wizzarts.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Wizzarts.Data.Models;

    public class CardGameExpansionSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CardGameExpansions.Any())
            {
                return;
            }

            await dbContext.CardGameExpansions.AddAsync(new CardGameExpansion
            {
                Title = "Alpha",
                Description = "Core Game",
                CardsCount = "10",
                ExpansionSymbolUrl = "/images/symbols/expansions/Alpha.png",
            });
            await dbContext.CardGameExpansions.AddAsync(new CardGameExpansion
            {
                Title = "Second",
                Description = "This is the pre-beta deck where our community helped us prepare for the beta release.",
                CardsCount = "13",
                ExpansionSymbolUrl = "/images/symbols/expansions/Second.png",
            });
            await dbContext.CardGameExpansions.AddAsync(new CardGameExpansion
            {
                Title = "Beta",
                Description = "Core game",
                CardsCount = "31",
                ExpansionSymbolUrl = "/images/symbols/expansions/Beta.png",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
