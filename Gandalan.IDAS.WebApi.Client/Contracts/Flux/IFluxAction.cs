namespace Gandalan.IDAS.Client.Contracts.Flux;

public enum CallMode
{
    /// <summary>
    /// retry until success or max retries reached, then throw exception if still not successful
    /// </summary>
    Guaranteed,

    /// <summary>
    /// retry until success or max retries reached
    /// </summary>
    BestEffort,

    /// <summary>
    /// try once, ignore failures
    /// </summary>
    FireAndForget,
}

public interface IFluxAction
{
    CallMode CallMode { get; set; }
    int MaxRetries { get; set; }
    int RetryCount { get; set; }

    object Payload { get; }
    string Verb { get; }

    void Deconstruct(out string verb, out object payload);
}
