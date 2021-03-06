﻿using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class TextRepresentation
    {

        [JsonProperty("language", Required = Required.Default)]
        public string Language { get; private set; }

        [JsonProperty("script", Required = Required.Default)]
        public string Script { get; private set; }

        public override string ToString() => $"{this.Language ?? "???"} / {this.Script ?? "????"}";

    }

}