namespace WebAppUpnQ8Api.ViewModels
{
    public class SubscribeServiceQuery
    {
        public int? RequestStatus { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
