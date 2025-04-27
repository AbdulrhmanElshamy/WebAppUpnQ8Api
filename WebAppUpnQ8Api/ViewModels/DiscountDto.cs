using System.ComponentModel.DataAnnotations;

namespace WebAppUpnQ8Api.ViewModels
{
    public class DiscountDto
    {
        [Key]
        public int Discount_ID { get; set; }

        [Required]
        public decimal DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
        public string Description_Ar { get; set; }

        [Required]
        public int Service_ID { get; set; }
    }
}
