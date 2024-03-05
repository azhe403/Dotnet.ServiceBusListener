using System.Diagnostics.CodeAnalysis;

namespace ServiceBusListener.Common
{
    [ExcludeFromCodeCoverage]
    public class ServiceBusRequest
    {
        public string transactionId { get; set; }
        public string? feURL { get; set; }
        public string action { get; set; }
        public string method { get; set; }
        public string source { get; set; }
        public int username { get; set; }
        public int status { get; set; }
        public string? entity { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string filter { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ServiceBusRequest<T> where T : class
    {
        public string transactionId { get; set; }
        public string? feURL { get; set; }
        public string action { get; set; }
        public string method { get; set; }
        public string source { get; set; }
        public int username { get; set; }
        public int status { get; set; }
        public string? entity { get; set; }
        public string filter { get; set; }
        public T data { get; set; }
        public T payload { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}