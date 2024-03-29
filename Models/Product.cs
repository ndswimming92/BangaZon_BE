﻿namespace BangaZon_ND.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? QuantityAvailable { get; set; }
        public int? PricePerUnit { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? TimePosted { get; set; }
        public int UserId { get; set; }

        public Boolean? UserIsSeller { get; set; }

    }
}
