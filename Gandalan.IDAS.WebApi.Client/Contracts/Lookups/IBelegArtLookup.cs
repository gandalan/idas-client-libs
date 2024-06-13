namespace Gandalan.Client.Contracts;

public interface IBelegArtLookup : ILookupDialog<IBelegArtLookupResult, IBelegArtLookupParams>
{
}

public interface IBelegArtLookupParams
{
    string[] BelegArten { get; }
}

public interface IBelegArtLookupResult
{
    string BelegArt { get; }
}

public class BelegArtLookupParams : IBelegArtLookupParams
{
    public string[] BelegArten { get; set; }
}

public class BelegArtLookupResult : IBelegArtLookupResult
{
    public static BelegArtLookupResult Empty { get; }
    public string BelegArt { get; set; }
}