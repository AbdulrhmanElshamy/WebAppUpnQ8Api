using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class CountriesTbl
    {
        [Key]
        public int Country_ID { get; set; }
        public string ISO { get; set; }
        public string Country_Name_Eng { get; set; }
        public string Country_Flag { get; set; }

        public virtual ICollection<CitiesTbl> CitiesTbls { get; set; }
        public virtual ICollection<CodeNumbersTbl> CodeNumbersTbls { get; set; }
    }
}
