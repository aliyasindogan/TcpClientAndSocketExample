namespace TcpClientAndSocketExample
{
    public class BaseRequest
    {
        public string IpAddress { get; set; }
        public int TcpPort { get; set; }
        public string SendData { get; set; }
        public string FinishValue { get; set; }
    }
}