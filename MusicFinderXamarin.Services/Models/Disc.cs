﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Disc
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; private set; }

        [JsonProperty("offset-count", Required = Required.Always)]
        public int OffsetCount { get; private set; }

        [JsonProperty("offsets", Required = Required.DisallowNull)]
        public IReadOnlyList<int> Offsets { get; private set; }

        public IReadOnlyList<Release> Releases => this._releases;

        [JsonProperty("releases", Required = Required.DisallowNull)]
        private Release[] _releases = null;

        [JsonProperty("sectors", Required = Required.Always)]
        public int Sectors { get; private set; }

        public override string ToString() => $"{this.Id} ({this.OffsetCount} track(s), {new TimeSpan(0, 0, 0, 0, (int)((double)this.Sectors / 75 * 1000)),2})";

    }

}