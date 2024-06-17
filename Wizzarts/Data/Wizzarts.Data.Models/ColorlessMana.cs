﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Wizzarts.Data.Common.Models;

namespace Wizzarts.Data.Models
{
    public class ColorlessMana : BaseDeletableModel<int>
    {
        public ColorlessMana()
        {
            this.Cards = new HashSet<PlayCard>();
        }

        [Comment("Play Card Total Cost")]
        public int Cost { get; set; }

        [Comment("Play Card Mana Conor Name")]
        public string ColorName { get; set; } = string.Empty;

        [Comment("Play Card Remote URL. Seeded.")]
        public string ImageUrl { get; set; } = string.Empty;

        public virtual ICollection<PlayCard> Cards { get; set; }
    }
}
