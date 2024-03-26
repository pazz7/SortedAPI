namespace SortedAPI.Domain
{
    public class Error
    {
        public string Message { get; set; }
        public ErrorDetail[] Details { get; set; }
    }
}