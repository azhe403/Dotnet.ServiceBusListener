namespace ServiceBusListener.Actions;

public class RndAction(Logger<RndAction> logger)
{
    [Action(Name = "HelloAction")]
    public void Hello()
    {
        logger.LogInformation("Receiving a message from Hello");
    }
}