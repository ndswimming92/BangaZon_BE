namespace BangaZon_ND.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? QuantityAvailable { get; set; }
        public int? PricePerUnit { get; set; }
        public string? CategoryId { get; set; }
        public string? TimePosted { get; set; }
        public string? UserId { get; set; }

    }
}
