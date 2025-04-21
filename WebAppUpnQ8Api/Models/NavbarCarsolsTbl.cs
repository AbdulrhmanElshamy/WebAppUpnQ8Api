using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class NavbarCarsolsTbl
    {
        [Key]
        public int NavbarCarsol_ID { get; set; }
        public string Image { get; set; }
        public string Tilte { get; set; }
        public string Tilte_Ar { get; set; }
        public string Description { get; set; }
        public string Description_Ar { get; set; }
    }
}
