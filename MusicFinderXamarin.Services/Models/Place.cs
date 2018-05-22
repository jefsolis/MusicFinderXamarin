using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Place
    {
        [JsonProperty("id", Required = Required.Always)]
        public Guid MbId { get; private set; }

        [JsonProperty("address", Required = Required.Default)]
        public string Address { get; private set; }

        public IReadOnlyList<Alias> Aliases => this._aliases;

        [JsonProperty("aliases", Required = Required.DisallowNull)]
        private Alias[] _aliases = null;

        [JsonProperty("annotation", Required = Required.Default)]
        public string Annotation { get; private set; }

        public Area Area => this._area;

        [JsonProperty("area", Required = Required.Default)]
        private Area _area = null;

        public Coordinates Coordinates => this._coordinates;

        [JsonProperty("coordinates", Required = Required.Default)]
        private Coordinates _coordinates = null;

        [JsonProperty("disambiguation", Required = Required.DisallowNull)]
        public string Disambiguation { get; private set; }

        public LifeSpan LifeSpan => this._lifeSpan;

        [JsonProperty("life-span", Required = Required.DisallowNull)]
        private LifeSpan _lifeSpan = null;

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
        // - the area is not serialized when the place is part of a relationship
        // - the address is not serialized when not set (instead of being serialized as null)
        // - the coordinates are not serialized when not set (instead of being serialized as null)
        // - the disambiguation comment is not serialized when not set (instead of being serialized as an empty string)
        // - the type and type ID are not serialized when not set (instead of being serialized as null)
        // => Adjusted the Required flags for affected properties (to allow their omission).

        #endregion

        public override string ToString()
        {
            var text = this.Name ?? string.Empty;
            if (!string.IsNullOrEmpty(this.Disambiguation))
                text += " (" + this.Disambiguation + ")";
            if (this.Type != null)
                text += " (" + this.Type + ")";
            return text;
        }

    }

}