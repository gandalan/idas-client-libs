namespace Gandalan.IDAS.WebApi.Client.Contracts.Settings
{
    public interface Inheritance
    {
        InheritanceMode Mode { get; set; }
    }

    public enum InheritanceMode
    {
        Default = 0,
        ReadOnly = 1,
        ReadWrite = 2,
        ReadOnlyInherited = 4,
    }
}
