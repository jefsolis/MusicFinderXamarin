using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Coordinates
    {
        [JsonProperty("latitude", Required = Required.Always)]
        public double Latitude { get; private set; }

        [JsonProperty("longitude", Required = Required.Always)]
        public double Longitude { get; private set; }

        public override string ToString() => $"({this.Latitude:F6}, {this.Longitude:F6})";

    }

}