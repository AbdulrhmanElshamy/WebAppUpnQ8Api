namespace WebAppUpnQ8Api.ViewModels
{
    public class SubServiceQueryParameters
    {
        public int ServiceId { get; set; }
        public string? Title { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
