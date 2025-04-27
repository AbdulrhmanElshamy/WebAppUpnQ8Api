using UPNprojectApi.Models;

namespace WebAppUpnQ8Api.ViewModels
{
    public class ServiceRequestQuery
    {
        public ServiceRequestStatus? RequestStatus { get; set; }
        public string? CustomerId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
