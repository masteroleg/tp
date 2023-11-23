namespace TracevitPro.messageBus;

public record BusEndpoint
{
    public BusEndpoint(string target) 
    {
        Target = target;
    }
    public string Target       { get; set; }
    public override string ToString() => Target;
}