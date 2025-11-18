namespace Gandalan.IDAS.Contracts.Mandanten;

/// <summary>
/// Enitity with optional Mandant Id
/// </summary>
public interface INullableMandantEntity
{
    long? MandantId { get; set; }
}
