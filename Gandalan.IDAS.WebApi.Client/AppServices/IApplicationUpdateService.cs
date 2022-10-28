using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.Client.Contracts.UIServices;

namespace Gandalan.Client.Contracts.AppServices
{
    /// <summary>
    /// Check for application updates 
    /// </summary>
    public interface IApplicationUpdateService
    {
        /// <summary>
        /// Progress in percent
        /// </summary>
        int Progress { get; }
        /// <summary>
        /// Info for user
        /// </summary>
        string StatusText { get; }

        /// <summary>
        /// Relative Installpath for updated I3 Version
        /// </summary>
        string VersionDir { get; }

        /// <summary>
        /// Wether or not there are updates available. Should return
        /// as quick as possible and not display progress
        /// </summary>
        /// <returns>status bool</returns>
        Task<bool> HasUpdates();
        /// <summary>
        /// Performs the actual update (with progress indicator)
        /// </summary>
        /// <returns>void</returns>
        Task UpdateApplication();
    }
}
