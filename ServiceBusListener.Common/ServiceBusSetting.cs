using System.ComponentModel.DataAnnotations;

namespace ServiceBusListener.Common;

public class ServiceBusSetting
{
    public const string SectionName = "ServiceBus";
    
    [Required(ErrorMessage = "Service Bus Connection is required")]
    public required string Connection { get; set; }
}