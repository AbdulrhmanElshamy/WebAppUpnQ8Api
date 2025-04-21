namespace WebAppUpnQ8Api.ViewModels
{
    public class ServiceQueryParameters
    {
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
