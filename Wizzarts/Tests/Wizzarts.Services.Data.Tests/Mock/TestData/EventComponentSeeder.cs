﻿namespace Wizzarts.Services.Data.Tests.Mock
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Wizzarts.Data;
    using Wizzarts.Data.Models;
    using Wizzarts.Services.Data.Tests.Mock;

    public class EventComponentSeeder : ITestDbSeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext)
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
                Title = "Test this card.",
                Description = "This is a newly created card by one of the event participants.",
                Instructions = "Use the printing tool. Print your card and test how it plays during a game. A specific tool for rating the card, pointing its weaknesses and strong points and what should the card creator work on." +
                "Click on the Test button and you will be redirected to the list of event cards. Once the test has been completed, Share your feedback with us.",
                EventId = 4,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}