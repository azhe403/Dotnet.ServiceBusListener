namespace ServiceBusListener.Common;

[AttributeUsage(AttributeTargets.Method)]
public class ActionAttribute : Attribute
{
    public string Name { get; set; }
}