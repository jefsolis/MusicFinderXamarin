using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Disc
    {
        [JsonProperty("id", Required = Required.Default)]
        public string Id { get; private set; }

        [JsonProperty("offset-count", Required = Required.Default)]
        public int OffsetCount { get; private set; }

        [JsonProperty("offsets", Required = Required.Default)]
        public IReadOnlyList<int> Offsets { get; private set; }

        public IReadOnlyList<Release> Releases => this._releases;

        [JsonProperty("releases", Required = Required.Default)]
        private Release[] _releases = null;

        [JsonProperty("sectors", Required = Required.Default)]
        public int Sectors { get; private set; }

        public override string ToString() => $"{this.Id} ({this.OffsetCount} track(s), {new TimeSpan(0, 0, 0, 0, (int)((double)this.Sectors / 75 * 1000)),2})";

    }

}