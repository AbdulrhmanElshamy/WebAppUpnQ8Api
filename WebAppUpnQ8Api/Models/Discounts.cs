using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class Discounts
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

        [ForeignKey(nameof(Service_ID))]
        public virtual ServicesTbl Service { get; set; }
    }

}
