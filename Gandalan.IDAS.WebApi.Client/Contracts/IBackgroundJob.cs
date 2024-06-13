using System.Threading.Tasks;

namespace Gandalan.IDAS.Jobs.Contracts;

public interface IBackgroundJob
{
    object JobData { get; }

    Task RunAsync(object jobData);
}

/// <summary>
/// Definiert einen Hintergrundjob, der unabhängig von der
/// eigentlichen Anwendung ausgeführt wird
/// </summary>
public interface IBackgroundJob<TJobData> : IBackgroundJob where TJobData : IJobData
{
    new TJobData JobData { get; }

    Task RunAsync(TJobData jobData);
}