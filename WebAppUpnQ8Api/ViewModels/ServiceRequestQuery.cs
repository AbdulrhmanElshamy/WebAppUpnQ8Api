namespace WebAppUpnQ8Api.ViewModels
{
    public class ServiceRequestQuery
    {
        public int? RequestStatus { get; set; }
        public int? CustomerId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
