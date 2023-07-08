using System.Net;

namespace Domain.Wrapper;

public class PagedResponce<T> : Responce<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPage { get; set; }
    public int TotalRecords { get; set; }

    public PagedResponce(T data, int totalRecords, int pageSize, int pageNumber) : base(data)
    {
        TotalRecords = totalRecords;
        PageSize = pageSize;
        PageNumber = pageNumber;
        TotalPage = (int)Math.Ceiling(totalRecords / (double)pageSize);
    }

    public PagedResponce(HttpStatusCode statusCode, List<string> errors) : base(statusCode, errors)
    {
        
    }
    public PagedResponce(HttpStatusCode statusCode, string error) : base(statusCode, error)
    {
        
    }
}