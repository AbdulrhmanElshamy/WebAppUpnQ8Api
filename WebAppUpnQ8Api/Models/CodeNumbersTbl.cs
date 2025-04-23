using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppUpnQ8Api.Models;

namespace UPNprojectApi.Models
{
    public class CodeNumbersTbl
    {
        [Key]
        public int Code_Number_ID { get; set; }
        public string Code_Number { get; set; }
        [ForeignKey ("CountriesTbl")]
        public int Country_ID { get; set; }

        public virtual CountriesTbl CountriesTbl { get; set; }
        public virtual ICollection<ApplicationUser> CustomersTbls { get; set; }
     //   public virtual ICollection<CustomersTbl> CustomersTbls1 { get; set; }

    }
}
