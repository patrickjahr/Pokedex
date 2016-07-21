using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeDex.Core.Services
{
    public interface ICustomSerializerService
    {
        T DeserializeFromJsonWithConcreteTypes<T>(string data);
        string SerializeAsJsonWithConcreteTypes<T>(T obj);

        /// <summary>
        /// Serializes the object as json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="serializerSettings">The optional serializer settings.</param>
        /// <returns></returns>
        string SerializeAsJson<T>(T obj, JsonSerializerSettings serializerSettings = null);

        /// <summary>
        /// Deserializes an object from a json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="serializerSettings">The optional serializer settings.</param>
        /// <returns></returns>
        T DeserializeFromJson<T>(string data, JsonSerializerSettings serializerSettings = null);

        /// <summary>
        /// Deserializes the json value from the given dictionary for the give searchKey.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="searchKey">The search key.</param>
        /// <param name="serializerSettings">The optional serializer settings.</param>
        /// <returns></returns>
        T DeserializeJsonValue<T>(Dictionary<string, Object> data, string searchKey, JsonSerializerSettings serializerSettings = null);
    }
}