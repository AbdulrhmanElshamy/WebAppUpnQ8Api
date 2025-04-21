using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class HomeImagesTbl
    {
        [Key]
        public int Home_Image_ID { get; set; }
        public string Home_Image_Path { get; set; }
        public string Home_Image_Place { get; set; }
    }
}
