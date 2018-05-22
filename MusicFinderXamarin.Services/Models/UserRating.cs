using System;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class UserRating
    {
        [JsonProperty("value", Required = Required.AllowNull)]
        public decimal? Value { get; private set; }

        public override string ToString()
        {
            var text = string.Empty;
            if (this.Value.HasValue)
            {
                var stars = Math.Round(this.Value.Value, MidpointRounding.AwayFromZero);
                for (var i = 1; i <= 5; ++i)
                    text = string.Concat(text, (stars >= i) ? '★' : '☆');
            }
            return text;
        }

    }

}