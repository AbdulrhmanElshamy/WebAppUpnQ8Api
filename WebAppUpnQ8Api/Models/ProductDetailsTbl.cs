using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class ProductDetailsTbl
    {
        [Key]
        public int Product_Detail_ID { get; set; }
        public string Detail_Description_Ar { get; set; }
        public string Detail_Description_Eng { get; set; }
        public Nullable<int> Product_ID { get; set; }
    }
}
