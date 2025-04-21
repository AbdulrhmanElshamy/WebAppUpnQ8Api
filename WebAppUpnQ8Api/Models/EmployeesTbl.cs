using System.ComponentModel.DataAnnotations;

namespace UPNprojectApi.Models
{
    public class EmployeesTbl
    {
        [Key]
        public int Employee_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Department_Name { get; set; }
        public string Position_Name { get; set; }
        public Nullable<int> Experince_Years { get; set; }
        public Nullable<System.DateTime> Birth_Day_Date { get; set; }
        public Nullable<long> Personal_Phone_Number { get; set; }
        public Nullable<long> Job_Phone_Number { get; set; }
        public string Employee_Image { get; set; }
        public string Facebook_Url { get; set; }
        public string Instagram_Url { get; set; }
        public string Twiter_Url { get; set; }
        public string Linkedin_Url { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
    }
}
