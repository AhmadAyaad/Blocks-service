using Newtonsoft.Json;

namespace Tahalouf.App.Helpers
{
    public class JsonHelpers
    {
        public static T ReadFile<T>(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                T t = JsonConvert.DeserializeObject<T>(json);
                return t;
            }
        }
    }
}
