using System;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class WorkAttribute
    {
        [JsonProperty("type", Required = Required.Default)]
        public string Type { get; private set; }

        [JsonProperty("type-id", Required = Required.Default)]
        public Guid? TypeId { get; private set; }

        [JsonProperty("value", Required = Required.Default)]
        public string Value { get; private set; }

        [JsonProperty("value-id", Required = Required.Default)]
        public Guid? ValueId { get; private set; }

        public override string ToString() => $"{this.Type}: {this.Value}";

    }

}