﻿namespace WebAppUpnQ8Api.ViewModels
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int LastPage { get; set; }

        public PagedResult(List<T> items, int totalCount, int page, int pageSize,int lastPage)
        {
            Items = items;
            TotalCount = totalCount;
            Page = page;
            PageSize = pageSize;
            LastPage = lastPage;
        }
    }

}
