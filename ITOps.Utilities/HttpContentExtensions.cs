using Newtonsoft.Json;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITOps.Utilities
{
    public static class HttpContentExtensions
    {
        public static ExpandoObject AsExpando(this object obj, JsonSerializerSettings jsonSerializerSettings)
            => JsonConvert.DeserializeObject<ExpandoObject>(JsonConvert.SerializeObject(obj, jsonSerializerSettings), jsonSerializerSettings);

        public static async Task<T> AsAsync<T>(this HttpContent content, JsonSerializerSettings jsonSerializerSettings)
            => JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync(), jsonSerializerSettings);

        public static T As<T>(this ExpandoObject expando, JsonSerializerSettings jsonSerializerSettings)
            => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(expando, jsonSerializerSettings), jsonSerializerSettings);

        public static async Task<ExpandoObject> AsExpandoAsync(this HttpContent content, JsonSerializerSettings jsonSerializerSettings)
            => JsonConvert.DeserializeObject<ExpandoObject>(await content.ReadAsStringAsync(), jsonSerializerSettings);

        public static async Task<ExpandoObject[]> AsExpandoArrayAsync(this HttpContent content, JsonSerializerSettings jsonSerializerSettings)
            => JsonConvert.DeserializeObject<ExpandoObject[]>(await content.ReadAsStringAsync(), jsonSerializerSettings);
    }
}