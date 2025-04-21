namespace WebAppUpnQ8Api.ViewModels
{
    public class SubFeatureQueryParameters
    {
        public int SubServiceId { get; set; }
        public string? Text { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
