﻿namespace Wizzarts.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Wizzarts.Data.Common.Repositories;
    using Wizzarts.Data.Models;
    using Wizzarts.Services.Mapping;
    using Wizzarts.Web.ViewModels.WizzartsMember;

    using static Wizzarts.Common.GlobalConstants;
    using static Wizzarts.Common.MembershipConstants;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<Art> artRepository;
        private readonly IDeletableEntityRepository<Article> articleRepository;
        private readonly IDeletableEntityRepository<PlayCard> playCardRepository;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IDeletableEntityRepository<Avatar> avatarRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UserService(
           IDeletableEntityRepository<Art> artRepository,
           IDeletableEntityRepository<Article> articleRepository,
           IDeletableEntityRepository<PlayCard> playCardRepository,
           IDeletableEntityRepository<Event> eventRepository,
           IDeletableEntityRepository<Avatar> avatarRepository,
           UserManager<ApplicationUser> userManager,
           IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.artRepository = artRepository;
            this.articleRepository = articleRepository;
            this.playCardRepository = playCardRepository;
            this.eventRepository = eventRepository;
            this.avatarRepository = avatarRepository;
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public T GetById<T>(string id)
        {
            var user = this.userRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return user;
        }

        public IEnumerable<T> GetAllArtByUserId<T>(string id)
        {
            var art = this.artRepository.AllAsNoTracking()
               .Where(x => x.AddedByMemberId == id)
               .To<T>().ToList();

            return art;
        }

        public IEnumerable<T> GetAllAvatars<T>()
        {
            var avatars = this.avatarRepository.AllAsNoTracking()
                .To<T>().ToList();

            return avatars;
        }

        public int GetCountOfArt(string id)
        {
            var artCount = this.artRepository
                .AllAsNoTracking()
                .Count(x => x.AddedByMemberId == id);

            return artCount;
        }

        public int GetCountOfArticles(string id)
        {
            var artCount = this.articleRepository
                .AllAsNoTracking()
                .Count(x => x.ArticleCreatorId == id);

            return artCount;
        }

        public int GetCountOfEvents(string id)
        {
            var artCount = this.eventRepository
                .AllAsNoTracking()
                .Count(x => x.EventCreatorId == id);

            return artCount;
        }

        public T GetAvatarById<T>(int id)
        {
            var avatar = this.avatarRepository.AllAsNoTracking()
               .Where(x => x.Id == id)
               .To<T>().FirstOrDefault();

            return avatar;
        }

        public async Task UpdateAsync(string id, CreateMemberProfileViewModel input)
        {
            var user = this.userRepository.All().FirstOrDefault(x => x.Id == id);
            user.Nickname = input.Nickname;
            user.AvatarUrl = input.AvatarUrl;
            user.Bio = input.Bio;
            user.AvatarId = input.AvatarId;
            user.PhoneNumber = input.Phone;

            await this.userRepository.SaveChangesAsync();
        }

        public async Task<string> UpdateRoleAsync(ApplicationUser user, string id)
        {
            var currentRole = await this.userManager.GetRolesAsync(user);

            var countOfArts = this.GetCountOfArt(id);

            var countOfArticles = this.GetCountOfArticles(id);

            var countOfEvents = this.GetCountOfEvents(id);

            var countOfCards = this.GetCountOfCards(id);
            var message = string.Empty;

            if (currentRole.Contains(MemberRoleName))
            {
                if (countOfArts >= MemberToArtistRequiredArts)
                {
                    await this.userManager.AddToRoleAsync(user, ArtistRoleName);
                }
                else if (countOfArticles >= RequiredNumberArticles && countOfEvents >= RequiredNumberEvents && countOfCards >= RequiredNumberEventCards)
                {
                    await this.userManager.AddToRoleAsync(user, PremiumRoleName);
                }
                else
                {
                    var artNeededMember = MemberToArtistRequiredArts - countOfArts;

                    var eventsNeededMember = RequiredNumberEvents - countOfEvents;

                    var articlesNeededMember = RequiredNumberArticles - countOfArticles;

                    var cardsNeededMember = RequiredNumberEventCards - countOfCards;

                    message = $"You own the {MemberRoleName} role. To become an artist you need {artNeededMember} art pieces." + $" To get premium access you need artist role or" +
                        $" {eventsNeededMember} event(s) created, {articlesNeededMember} article(s) and {cardsNeededMember} event card(s).";
                }
            }
            else if (currentRole.Contains(PremiumRoleName))
            {
                message = $"You have a premium account.";
            }
            else if (currentRole.Contains(ArtistRoleName))
            {
                message = $"You are an artist. Artists have premium access";
            }
            else
            {
                message = $"You are a member.";
            }

            return message;
        }

        public int GetCountOfCards(string id)
        {
            var cardsCount = this.playCardRepository
                .AllAsNoTracking()
                .Count(x => x.AddedByMemberId == id && x.IsEventCard == true);

            return cardsCount;
        }

        public async Task<bool> IsPremium(string userId)
        {
            var user = this.userRepository.All().FirstOrDefault(x => x.Id == userId);
            var currentRole = await this.userManager.GetRolesAsync(user);

            return currentRole.Contains(ArtistRoleName) || currentRole.Contains(PremiumRoleName);

        }
    }
}