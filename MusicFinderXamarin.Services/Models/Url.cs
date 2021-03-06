﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Url
    {
        [JsonProperty("id", Required = Required.Default)]
        public Guid MbId { get; private set; }

        public IReadOnlyList<Relationship> Relationships => this._relationships;

        [JsonProperty("relations", Required = Required.Default)]
        private Relationship[] _relationships = null;

        [JsonProperty("resource", Required = Required.Default)]
        public Uri Resource { get; private set; }

        public override string ToString() => this.Resource.ToString();

    }

}