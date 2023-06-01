namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public enum CallMode
    {
        // retry until success or max retries reached, then throw exception if still not successful
        Guaranteed,
        // retry until success or max retries reached
        BestEffort,
        // try once, ignore failures
        FireAndForget
    };

    public interface IFluxAction
    {
        CallMode CallMode { get; set; }
        int MaxRetries { get; set; }
        int RetryCount { get; set; }

        object Payload { get; }
        string Verb { get; }

        void Deconstruct(out string verb, out object payload);
    }
}
