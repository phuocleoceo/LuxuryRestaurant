namespace Common.BO
{
    public class RequestModel<T>
    {
        public string RequestType { get; set; }

        public T Entity { get; set; }
    }
}
