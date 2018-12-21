using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ff_platform.Extensions
{
    public class Deserializer
    {
        public static T TryGetValue<T>(JToken token)
        {
            try
            {
                return token.ToObject<T>();
            }
            catch
            {
                return default(T);
            }
        }

        public static T TryGetValue<T>(JToken token, string key)
        {
            try
            {
                return token[key].ToObject<T>();
            }
            catch
            {
                return default(T);
            }
        }

        public static T FromJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }
        }

        public static T ConvertToken<T>(JToken token)
        {
            try
            {
                return token.ToObject<T>();
            }
            catch
            {
                return default(T);
            }
        }
    }


    public class Serializer
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
