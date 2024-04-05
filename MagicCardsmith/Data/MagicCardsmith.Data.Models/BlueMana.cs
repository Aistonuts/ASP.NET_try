﻿namespace MagicCardsmith.Data.Models
{
    using System.Collections.Generic;

    using MagicCardsmith.Data.Common.Models;

    public class BlueMana : BaseDeletableModel<int>
    {
        public BlueMana()
        {
            this.Cards = new HashSet<Card>();
        }

        public int Cost { get; set; }

        public string ColorName { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}