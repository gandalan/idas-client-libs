namespace Gandalan.IDAS.WebApi.Util;

public class ObjectCloner
{
    public static T Clone<T>(T obj)
    {
        var jsonString = System.Text.Json.JsonSerializer.Serialize(obj);
        return System.Text.Json.JsonSerializer.Deserialize<T>(jsonString);
    }
}
