using System.Net;

namespace Domain.Wrapper;

public class Responce<T>
{
    public T Data { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    public HttpStatusCode StatusCode { get; set; } // 200
    public Responce(T data)
    {
        Data = data;
        StatusCode = HttpStatusCode.OK;
    }

    public Responce(HttpStatusCode statusCode, List<string> errors)
    {
        StatusCode = statusCode;
        Errors = errors;            
    }
    
    public Responce(HttpStatusCode statusCode, string error)
    {
        StatusCode = statusCode;
        Errors = new List<string>(){error};        
    }
}