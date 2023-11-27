﻿namespace MagicCardsHub.Data.Models
{
    using MagicCardsHub.Data.Common.Models;

    public class VarSymbols : BaseDeletableModel<int>
    {
        public string CardExpansion { get; set; }

        public string CardRarity { get; set; }

        public string RemoteImageUrl { get; set; }

        public string Extension { get; set; }

        public string CardId { get; set; }

        public Card Card { get; set; }
    }
}