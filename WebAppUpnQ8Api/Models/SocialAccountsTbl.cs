using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class SocialAccountsTbl
    {
        [Key]
        public int SocialAccount_ID { get; set; }
        public string Logo { get; set; }
        public string Social_Name { get; set; }
        public string Account_URL { get; set; }
    }
}
