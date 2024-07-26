namespace Domain.Models;

public class BaseResponse<T>
{
    public List<T>? Content { get; set; }
}