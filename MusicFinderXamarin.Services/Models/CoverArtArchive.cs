﻿using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class CoverArtArchive
    {
        [JsonProperty("artwork", Required = Required.Always)]
        public bool Artwork { get; private set; }

        [JsonProperty("back", Required = Required.Always)]
        public bool Back { get; private set; }

        [JsonProperty("count", Required = Required.Always)]
        public int Count { get; private set; }

        [JsonProperty("darkened", Required = Required.Always)]
        public bool Darkened { get; private set; }

        [JsonProperty("front", Required = Required.Always)]
        public bool Front { get; private set; }

        public override string ToString()
        {
            if (this.Darkened)
                return "<cover art taken down>";
            return (this.Count == 0) ? "<no cover art>" : $"{this.Count} item(s)";
        }

    }

}