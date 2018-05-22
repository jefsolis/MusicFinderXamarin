using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Instrument
    {
        [JsonProperty("id", Required = Required.Always)]
        public Guid MbId { get; private set; }

        public IReadOnlyList<Alias> Aliases => this._aliases;

        [JsonProperty("aliases", Required = Required.DisallowNull)]
        private Alias[] _aliases = null;

        [JsonProperty("annotation", Required = Required.Default)]
        public string Annotation { get; private set; }

        [JsonProperty("description", Required = Required.Default)]
        public string Description { get; private set; }

        [JsonProperty("disambiguation", Required = Required.DisallowNull)]
        public string Disambiguation { get; private set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; private set; }

        public IReadOnlyList<Relationship> Relationships => this._relationships;

        [JsonProperty("relations", Required = Required.DisallowNull)]
        private Relationship[] _relationships = null;

        public IReadOnlyList<Tag> Tags => this._tags;

        [JsonProperty("tags", Required = Required.DisallowNull)]
        private Tag[] _tags = null;

        [JsonProperty("type", Required = Required.Default)]
        public string Type { get; private set; }

        [JsonProperty("type-id", Required = Required.Default)]
        public Guid? TypeId { get; private set; }

        public IReadOnlyList<UserTag> UserTags => this._userTags;

        [JsonProperty("user-tags", Required = Required.DisallowNull)]
        private UserTag[] _userTags = null;

        #region Search Server Compatibility

        // The search server's serialization differs in the following ways:
        // - the description is not serialized when not set (instead of being serialized as null)
        // - the disambiguation comment is not serialized when not set (instead of being serialized as an empty string)
        // => Adjusted the Required flags for affected properties (to allow their omission).

        #endregion
    }
}