namespace Domain.Filters;

public class GetUserFilter : PaginationFilter
{
    public string UserName { get; set; }

    public GetUserFilter() : base()
    {
        
    }

    public GetUserFilter(int pageNumber, int pageSize) : base(pageNumber, pageSize)
    {
        
    }
}