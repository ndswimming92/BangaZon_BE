using System.ComponentModel.DataAnnotations.Schema;

namespace BangaZon_ND.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
     
        public int ProductId { get; set; }

    }
}
