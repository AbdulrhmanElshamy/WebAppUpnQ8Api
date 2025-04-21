using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class LoginUserTbl
    {
        [Key]
        public int Login_ID { get; set; }
        public string User_ID { get; set; }
        public Nullable<System.DateTime> Login_Date { get; set; }
        public string IP_Address { get; set; }
        public string Browser_Name { get; set; }
        public string OS_Name { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
    }
}
