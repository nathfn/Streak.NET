using System;
using Newtonsoft.Json;

namespace Streak.Net.Api.Models
{
    public class FieldValue : BaseObject
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        /// <summary>
        /// Tries to convert the value to a unix timestamp. 
        /// </summary>
        /// <returns></returns>
        public long? TryGetTimestampValue()
        {
            try
            {
                return (long)Value;
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        /// <summary>
        /// Tries to convert the value to a string
        /// </summary>
        /// <returns></returns>
        public string TryGetStringValue()
        {
            try
            {
                return Value.ToString();
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        /// <summary>
        /// Tries to convert the value to JSON and then return the e-mail
        /// </summary>
        /// <returns></returns>
        public string TryGetEmailValue()
        {
            try
            {
                return JsonConvert.DeserializeObject<FieldValueEmail>(Value.ToString()).Email;
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }
    }

    internal class FieldValueEmail
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
