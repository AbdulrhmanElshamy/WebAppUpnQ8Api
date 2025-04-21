using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPNprojectApi.Models
{
    public class TestmonialsTbl
    {
        [Key]
        public int Testmonial_ID { get; set; }
        [ForeignKey ("CustomersTbl")]
        public int Customer_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> Rating_Stars { get; set; }
        public string Testmonial_Note { get; set; }

        public virtual CustomersTbl CustomersTbl { get; set; }
    }
}
