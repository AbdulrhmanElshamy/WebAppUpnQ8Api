using Microsoft.AspNetCore.Mvc;

namespace WebAppUpnQ8Api.ViewModels.ServicesViewModels
{
    public class AddServiceModel
    {
        public Nullable<int> Service_ID { get; set; }
        public string Service_Title { get; set; }
        public string Service_Description { get; set; }
        public string Service_Title_Ar { get; set; }
        public string Service_Description_Ar { get; set; }
        //public string? Image { get; set; }
        public IFormFile? upload { get; set; }
    }


}
