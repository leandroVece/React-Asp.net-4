namespace Cadeteria;

public class Response<T>
{
    public Response()
    {
    }
    public Response(T data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        Succeeded = true;
        Message = string.Empty;
        Errors = null;
        Data = data;
    }
    public T? Data { get; set; }
    public bool Succeeded { get; set; }
    public string[] Errors { get; set; }
    public string Message { get; set; }
}