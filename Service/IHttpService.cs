public interface IHttpService
{
    Task<T?> Request<T>() where T : class;
}