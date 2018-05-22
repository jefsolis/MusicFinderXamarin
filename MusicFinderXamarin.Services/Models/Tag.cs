using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Tag
    {

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; private set; }

        [JsonProperty("count", Required = Required.Default)]
        public int VoteCount { get; private set; }

        //public override string ToString() => $"{(this.SearchScore.HasValue ? $"[Score: {this.SearchScore.Value}] " : "")}{this.Name} (votes: {this.VoteCount})";

    }

}