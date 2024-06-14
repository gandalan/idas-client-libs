namespace Gandalan.IDAS.Jobs.Contracts;

public interface IJobData
{
    bool ReportsProgress { get; set; }
    int ProgressPercent { get; set; }
    bool HasFinished { get; set; }
}