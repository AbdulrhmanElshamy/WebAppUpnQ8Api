﻿namespace WebAppUpnQ8Api.ViewModels
{
    public class ContentQueryParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; }
    }

}
