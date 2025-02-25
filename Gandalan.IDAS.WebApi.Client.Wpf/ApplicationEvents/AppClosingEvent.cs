using Gandalan.Client.Contracts;

namespace Gandalan.IDAS.WebApi.Client.Wpf.ApplicationEvents
{
    public class AppClosingEvent : IApplicationEvent
    {
        /// <summary>
        /// Indicates whether the closing operation can be canceled
        /// </summary>
        public bool CanCancel { get; set; }
        
        /// <summary>
        /// Set to true by any handler to cancel the application closing
        /// </summary>
        public bool IsCancelled { get; set; }
        
        /// <summary>
        /// Optional reason for cancellation that can be set by handlers
        /// </summary>
        public string CancellationReason { get; set; }
        
        public AppClosingEvent(bool canCancel = true)
        {
            CanCancel = canCancel;
            IsCancelled = false;
        }
    }
}
