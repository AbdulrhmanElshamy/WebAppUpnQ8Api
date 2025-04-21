using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppUpnQ8Api.ViewModels.CustomerViewModels
{
    public class CustomQuestionModel
    {
        public int Request_Quote_ID { get; set; }
        public Nullable<System.DateTime> Request_Date { get; set; }
        public Nullable<bool> Request_Status { get; set; }
        public string? Message { get; set; }
        public int Service_ID { get; set; }
        public string? Service_Title { get; set; }
    }
}
