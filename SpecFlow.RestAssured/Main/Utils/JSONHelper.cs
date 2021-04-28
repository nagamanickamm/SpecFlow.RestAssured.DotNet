using System.Text.Json;

namespace SpecFlow.RestAssure.Main.Utils
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
