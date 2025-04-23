using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebAppUpnQ8Api.Models;

namespace UPNprojectApi.Models
{
    public class CitiesTbl
    {
        [Key]
        public int City_ID { get; set; }
       
        public string City_Name_Ar { get; set; }
        public string City_Name_Eng { get; set; }
        [ForeignKey("CountriesTbl")]
        public int Country_ID { get; set; }

        public virtual CountriesTbl CountriesTbl { get; set; }
        public virtual ICollection<ApplicationUser> CustomersTbls { get; set; }
    }
}
