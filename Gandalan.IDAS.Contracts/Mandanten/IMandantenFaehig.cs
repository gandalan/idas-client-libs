namespace Gandalan.IDAS.Contracts.Mandanten;

/// <summary>
/// Interface for entities that support multi-tenancy
/// Replaces the complex [MandantenFaehig] attribute approach from EF 6
/// </summary>
public interface IMandantenFaehig
{
    long MandantId { get; set; }
}
