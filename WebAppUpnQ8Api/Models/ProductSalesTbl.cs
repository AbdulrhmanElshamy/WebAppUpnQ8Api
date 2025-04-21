using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class ProductSalesTbl
    {
        [Key]
        public int Product_Sale_ID { get; set; }
        [ForeignKey ("ProductsTbl")]
        public int Product_ID { get; set; }
        public string Id { get; set; }
        public Nullable<double> Sale_Price { get; set; }
        public Nullable<System.DateTime> Sale_Date { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual ProductsTbl ProductsTbl { get; set; }
    }
}
