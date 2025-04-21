using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class HomeTitlesTbl
    {
        [Key]
        public int Home_Title_ID { get; set; }
        public string Home_Title { get; set; }
        public string Home_Title_Place { get; set; }
    }
}
