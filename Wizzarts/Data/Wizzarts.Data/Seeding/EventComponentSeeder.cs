﻿namespace Wizzarts.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Wizzarts.Data.Models;

    public class EventComponentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.EventComponents.Any())
            {
                return;
            }

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Flavorless cards",
                Description = "Shady pond under the moonlight",
                ImageUrl = "/images/event/milestones/EventOneMilestones/Abandoned_Mire.png",
                EventId = 1,
                RequireArtInput = false,
            });
            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Flavorless cards",
                Description = "The glorious Adeline",
                ImageUrl = "/images/event/milestones/EventOneMilestones/Adeline.png",
                EventId = 1,
                RequireArtInput = false,
            });
            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Flavorless cards",
                Description = "Some items can be purchased only from the shady corners.",
                ImageUrl = "/images/event/milestones/EventOneMilestones/Black_Market.png",
                EventId = 1,
                RequireArtInput = false,
            });
            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Flavorless cards",
                Description = "The rise of the empire",
                ImageUrl = "/images/event/milestones/EventOneMilestones/Empire.png",
                EventId = 1,
                RequireArtInput = false,
            });
            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Flavorless cards",
                Description = "Almost visible creature creeping in the night.",
                ImageUrl = "/images/event/milestones/EventOneMilestones/Ghast.png",
                EventId = 1,
                RequireArtInput = false,
            });
            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Flavorless cards",
                Description = "Fear the uknown.",
                ImageUrl = "/images/event/milestones/EventOneMilestones/InfernalGrasp.png",
                EventId = 1,
                RequireArtInput = false,
            });
            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Flavorless cards",
                Description = "Pesky scavengers",
                ImageUrl = "/images/event/milestones/EventOneMilestones/Scavengers.png",
                EventId = 1,
                RequireArtInput = false,
            });
            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Demonic tutor",
                Description = "Search your library for a card and put that card into your hand. Then shuffle your library.",
                ImageUrl = "/images/event/milestones/EventTwoMilestones/Demonic_Tutor.png",
                EventId = 2,
                RequireArtInput = true,
            });
            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Wrath of God",
                Description = "Destroy all creatures. They can't be regenerated.",
                ImageUrl = "/images/event/milestones/EventTwoMilestones/Wrath_of_God.png",
                EventId = 2,
                RequireArtInput = true,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Timetwister",
                Description = "Each player shuffles their hand and graveyard into their library, then draws seven cards. (Then put Timetwister into its owner's graveyard.)",
                ImageUrl = "/images/event/milestones/EventTwoMilestones/Timetwister.png",
                EventId = 2,
                RequireArtInput = true,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Ankh of Mishra",
                Description = "Whenever a land enters the battlefield, Ankh of Mishra deals 2 damage to that land's controller.",
                ImageUrl = "/images/event/milestones/EventTwoMilestones/Ankh_Of_Mishra.png",
                EventId = 2,
                RequireArtInput = true,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Share with us the location of your store.",
                Instructions = "Click on the button below. Submit your store name, location and a picture.",
                Description = "Newly submitted store will appear on our store page.",
                EventId = 3,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Share with us the location of your store.",
                Instructions = "Click on the button below. Submit your store name, location and a picture.",
                Description = "Newly submitted store will appear on our store page.",
                EventId = 3,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Share with us the location of your store.",
                Instructions = "Click on the button below. Submit your store name, location and a picture.",
                Description = "Newly submitted store will appear on our store page.",
                EventId = 3,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Bright store game testers",
                Description = "The event will start on the 1 of July 2024.",
                ImageUrl = "/images/Stores/Bright.jpg",
                Instructions = "Pick your deck from your local store or from the Bright store. The event will start at 14. There will be a tournament.",
                EventId = 4,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Bright store game testers",
                Description = "The event will start on the 1 of July 2024, We will be waiting for you at Montpellier,23 Gabriel Peri 32000, France",
                ImageUrl = "/images/Stores/Bright.jpg",
                Instructions = "Pick your deck from your local store or from the Bright store. The event will start at 14. There will be a tournament.",
                EventId = 4,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Daytona Magic store game testers",
                Description = "The event will start on the 1 of July 2024, We will be waiting for you at Miami,23 34 Lower Keys 190, Florida",
                ImageUrl = "/images/Stores/Daytona_Magic.jpg",
                Instructions = "Pick your deck from your local store or from the Bright store. The event will start at 14. There will be a tournament.",
                EventId = 4,
            });

            await dbContext.EventComponents.AddAsync(new EventComponent
            {
                Title = "Yokohama store game testers",
                Description = "The event will start on the 1 of July 2024, We will be waiting for you at Yokohama,14 Sakura 34000 190, Japan",
                ImageUrl = "/images/Stores/Daytona_Magic.jpg",
                Instructions = "Pick your deck from your local store or from the Bright store. The event will start at 14. There will be a tournament.",
                EventId = 4,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}