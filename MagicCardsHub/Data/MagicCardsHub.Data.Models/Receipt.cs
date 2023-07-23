﻿namespace MagicCardsHub.Data.Models
{
    using System;

    using MagicCardsHub.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    public class Receipt : BaseDeletableModel<string>
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Precision(18, 2)]
        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }

        public string PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}