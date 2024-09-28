﻿// ReSharper disable VirtualMemberCallInConstructor
namespace Wizzarts.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Wizzarts.Data.Common.Models;

    using static Wizzarts.Common.DataConstants;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Articles = new HashSet<Article>();
            this.Cards = new HashSet<PlayCard>();
            this.Events = new HashSet<Event>();
            this.Stores = new HashSet<Store>();
            this.Votes = new HashSet<Vote>();
            this.Art = new HashSet<Art>();
            this.Comments = new HashSet<CommentCard>();
        }

        [MaxLength(UserNickNameMaxLength)]
        [PersonalData]
        public string Nickname { get; set; } = string.Empty;

        [Comment("Avatar Identifier.Picked after signing in")]
        public int? AvatarId { get; set; }

        [Required]
        [Comment("Avatar remote URL.Picked after signing in")]
        public string AvatarUrl { get; set; } = string.Empty;

        [Comment("Information about the artist")]
        public string Bio { get; set; } = string.Empty;

        public Avatar Avatar { get; set; }

        public string AdminFeedBack { get; set; } = string.Empty;

        public bool RequestFeedback { get; set; }

        public bool HasBeenUpdated { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        [Comment("Team MagicCardsmith art pieces")]
        public virtual ICollection<Art> ArtPieces { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<PlayCard> Cards { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<CardDeck> CardDecks { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Art> Art { get; set; }

        public virtual ICollection<CommentCard> Comments { get; set; }

        public ICollection<ChatUser> Chats { get; set; }

        public virtual ICollection<Event> JoinedEvents { get; set; }
    }
}
