using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class UserTag
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; private set; }

        public override string ToString() => this.Name;

    }

}