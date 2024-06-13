using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Util;

public class ObjectCloner
{
    public static T Clone<T>(T obj)
    {
            var jsonString = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
}