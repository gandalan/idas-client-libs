namespace Gandalan.IDAS.Contracts.Mandanten;

/// <summary>
/// Interface for providing current mandant context in a multi-mandant application
/// This replaces the static MandantId approach from EF 6 with modern dependency injection
/// </summary>
public interface IMandantProvider
{
    /// <summary>
    /// Gets the current mandant ID
    /// Returns 0 to indicate no mandant filtering (admin/system context)
    /// </summary>
    long CurrentMandantId { get; set; }
}

public interface IHttpContextMandantProvider : IMandantProvider;
