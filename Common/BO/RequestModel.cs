namespace Common.BO
{
    public class RequestModel<T>
    {
        public string Header { get; set; }

        public T Payload { get; set; }
    }
}
