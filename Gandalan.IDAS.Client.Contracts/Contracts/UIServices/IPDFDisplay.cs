namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IPDFDisplay
    {
        void DisplayPDF(string path);
    }

    public interface IPDFDisplayContainer
    {
        void SetControl(object control);
    }
}
