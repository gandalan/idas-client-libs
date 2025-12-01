namespace Gandalan.IDAS.Contracts.Mandanten;

/// <summary>
/// Mandant Entity
/// </summary>
public interface IMandantEntity
{
    void SetMandantId(long mandantId);
    long GetMandantId();
}
