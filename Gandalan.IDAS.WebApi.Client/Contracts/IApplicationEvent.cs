using System.Threading.Tasks;

namespace Gandalan.Client.Contracts;

public interface IApplicationEventHandler
{
    int Priority { get; set; }
}

/// <summary>
/// Register an event handler for a certain type of application event
/// </summary>
/// <typeparam name="TEvent">what kind of event do we want to be informed of</typeparam>
public interface IApplicationEventHandler<TEvent> : IApplicationEventHandler where TEvent : IApplicationEvent
{
    /// <summary>
    /// Handles a certain event that is dispatched to this instance
    /// </summary>
    Task HandleEvent(TEvent theEvent);
}

/// <summary>
/// Decoration interface for application events
/// </summary>
public interface IApplicationEvent
{
}

/// <summary>
/// Handles dispatching of application specific global events
/// </summary>
public interface IApplicationEventDispatcher
{
    /// <summary>
    /// Passes the event to all registered handlers for this event
    /// </summary>
    /// <param name="theEvent">event to dispatch</param>
    Task DispatchAsync(IApplicationEvent theEvent);
}
