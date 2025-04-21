using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppUpnQ8Api.ViewModels.CustomerViewModels
{
    public class GetCustomModel
    {
        public int Customer_ID { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public Nullable<System.DateTime> Birth_Day_Date { get; set; }
        public Nullable<long> Phone_Number_1 { get; set; }
        public Nullable<long> Phone_Number_2 { get; set; }
        public string? Address_1 { get; set; }
        public string? Address_2 { get; set; }
        public Nullable<int> Country_ID { get; set; }
        public string City_Name_Eng { get; set; }
        public string Country_Name_Eng { get; set; }
        public int? City_ID { get; set; }
        //public string? User_ID { get; set; }
        //public string? Image { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<System.DateTime> Register_Date { get; set; }
        public int? Code_Number_ID_1 { get; set; }
        public string? Code_Number { get; set; }
    }
}
