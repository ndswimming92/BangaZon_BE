namespace BangaZon_ND.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int? PaymentType { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? OrderStatus { get; set; }

        public int? ProductsId { get; set; }
    }
}
