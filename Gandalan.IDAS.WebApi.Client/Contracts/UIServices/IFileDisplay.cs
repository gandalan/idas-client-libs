namespace Gandalan.Client.Contracts.UIServices;

public interface IFileDisplay
{
    void DisplayFile(string path, string caption);
}

public interface IFileDisplayContainer
{
    void SetControl(object control);
}