﻿namespace Wizzarts.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Wizzarts.Data.Models;

    public class EventCategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.EventCategories.Any())
            {
                return;
            }

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Flavorless",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Imageless",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Create_article",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Add_playCard",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Add_art",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Create_deck",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Add_store",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Create_event",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Image",
            });

            await dbContext.EventCategories.AddAsync(new EventCategory
            {
                Title = "Text",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
