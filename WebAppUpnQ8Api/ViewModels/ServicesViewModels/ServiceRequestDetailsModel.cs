using UPNprojectApi.Models;

namespace WebAppUpnQ8Api.ViewModels.ServicesViewModels
{
    public class ServiceRequestDetailsModel
    {
        public int Service_Request_ID { get; set; }
        public string Customer_ID { get; set; }
        //public Nullable<bool> Service_Request_Statues { get; set; }
        public Nullable<System.DateTime> Service_Request_Date { get; set; }
        //public string ServiceRequestDate { get; set; }
        public Nullable<System.DateTime> Service_Response_Date { get; set; }
        //public string ServiceResponseDate { get; set; }
        public Nullable<int> Sub_Service_ID { get; set; }
        //public string Id { get; set; }
        public ServiceRequestStatus? Request_Status { get; set; }
        public Nullable<System.DateTime> Service_Active_Date { get; set; }
        public Nullable<System.DateTime> Finished_Date { get; set; }
        //public string ServiceActiveDate { get; set; }
        //public string FinishedDate { get; set; }
        public Nullable<double> Renewal_price { get; set; }
        public Nullable<bool> Renewal_request { get; set; }
        public string ? Requset_Code { get; set; }
        public string ? First_Name { get; set; }
        public string ? Last_Name { get; set; }

        public string ? Sub_Service_Title { get; set; }
        public string ? Service_Title { get; set; }
        public string? Sub_Service_Title_Ar { get; set; }
        public string? Service_Title_Ar { get; set; }
        //public string UserName { get; set; }
        //public int Days { get; set; }
        //public List<SubFeaturesTbl> subFeatures { get; set; }
    }
}
