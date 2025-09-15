using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Flux;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Flux;

public interface IFluxConsumer
{
    /// <summary>
    /// Determines the relative execution order when multiple consumers handle the same action.
    /// </summary>
    /// <value>
    /// Default is 1000. Lower values are invoked earlier than higher values.
    /// </value>
    /// <remarks>
    /// <para>
    /// Ordering applies to transient consumers that are collected and invoked in ascending
    /// <see cref="Priority"/> order. Persistent consumers are invoked in their registration order.
    /// </para>
    /// <para>
    /// Priority influences only the notification ordering within a single store dispatch; it does not
    /// guarantee global ordering across different stores or dispatch sources.
    /// </para>
    /// <para>
    /// Choose lower numbers for critical handlers that must run first, and higher numbers for
    /// non-critical or UI-related handlers.
    /// </para>
    /// </remarks>
    int Priority { get; }

    /// <summary>
    /// Maps action verbs to asynchronous handler functions that process those actions.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Keys are action verb strings (e.g., "set-xyz"). Matching is exact and case-sensitive
    /// because it relies on <see cref="IDictionary{TKey,TValue}.TryGetValue(TKey, out TValue)"/>.
    /// </para>
    /// <para>
    /// Initialize this map during construction or startup. Returning <c>null</c> (or leaving the map empty)
    /// indicates that the consumer does not handle any actions.
    /// </para>
    /// <para>
    /// Handlers are expected to be fast, awaitable, and resilient: prefer not to throw and
    /// instead handle and log errors internally. Handlers should be idempotent where possible,
    /// as the same action may be delivered more than once in certain scenarios.
    /// </para>
    /// <para>
    /// Common usage patterns:
    /// </para>
    /// <list type="bullet">
    ///   <item>
    ///     <description>Bind multiple verbs to dedicated handlers to keep logic cohesive.</description>
    ///   </item>
    ///   <item>
    ///     <description>Capture required services via closures when creating the handlers.</description>
    ///   </item>
    ///   <item>
    ///     <description>Guard against missing payloads and validate the action before use.</description>
    ///   </item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <![CDATA[
    /// // Example: configure the consumer's priority and handlers
    /// Priority = 1500; // run earlier than default (1000)
    ///
    /// ConsumerHandlerMap = new Dictionary<string, Func<IFluxStore, IFluxAction, Task>>
    /// {
    ///     { "set-uimachine-result", handleSetUiMachineResult },
    ///     { "save-vorgang", (store, action) => SaveAsync(store, action) },
    /// };
    /// ]]>
    /// </example>
    IDictionary<string, Func<IFluxStore, IFluxAction, Task>> ConsumerHandlerMap { get; set; }


    /// <summary>
    /// Represents an array of <see cref="IFluxStore"/> instances that are registered with the consumer.
    /// </summary>
    /// <value>
    /// Contains the stores that actively participate in handling actions dispatched to this consumer.
    /// </value>
    /// <remarks>
    /// <para>
    /// Registered stores provide the context and mechanisms for managing state and
    /// dispatching actions. Each store defines its own handler map and can be used to coordinate
    /// changes to application state through actions.
    /// </para>
    /// <para>
    /// By associating specific stores with a consumer, the consumer can listen for
    /// and handle targeted actions, facilitating modular and reactive application design.
    /// </para>
    /// </remarks>
    IFluxStore[] RegisteredStores { get; }
}
