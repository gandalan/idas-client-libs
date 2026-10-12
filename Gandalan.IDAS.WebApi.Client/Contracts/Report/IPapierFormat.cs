namespace Gandalan.IDAS.WebApi.Client.Contracts.Report;

public interface IPapierFormat
{
    string Name { get; set; }
    int Height { get; set; }
    int Width { get; set; }
    int WidthMM { get; }
    int HeightMM { get; }
}
