namespace Gandalan.IDAS.WebApi.Client.Contracts.Settings
{
    public interface Inheritanse
    {
        InheritanseMode Mode { get; set; }
    }

    public enum InheritanseMode
    {
        Default = 0,
        ReadOnly = 1,
        ReadWrite = 2,
        ReadOnlyInherited = 4,
    }
}
