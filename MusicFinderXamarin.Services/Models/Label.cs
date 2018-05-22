﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Label
    {
        [JsonProperty("id", Required = Required.Always)]
        public Guid MbId { get; private set; }

        public IReadOnlyList<Alias> Aliases => this._aliases;

        [JsonProperty("aliases", Required = Required.DisallowNull)]
        private Alias[] _aliases = null;

        [JsonProperty("annotation", Required = Required.Default)]
        public string Annotation { get; private set; }

        public Area Area => this._area;

        [JsonProperty("area", Required = Required.Default)]
        private Area _area = null;

        [JsonProperty("country", Required = Required.Default)]
        public string Country { get; private set; }

        [JsonProperty("disambiguation", Required = Required.DisallowNull)]
        public string Disambiguation { get; private set; }

        [JsonProperty("ipis", Required = Required.DisallowNull)]
        public IReadOnlyList<string> Ipis { get; private set; }

        [JsonProperty("isnis", Required = Required.DisallowNull)]
        public IReadOnlyList<string> Isnis { get; private set; }

        [JsonProperty("label-code", Required = Required.Default)]
        public int? LabelCode { get; private set; }

        public LifeSpan LifeSpan => this._lifeSpan;

        [JsonProperty("life-span", Required = Required.DisallowNull)]
        private LifeSpan _lifeSpan = null;

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; private set; }

        public Rating Rating => this._rating;

        [JsonProperty("rating", Required = Required.DisallowNull)]
        private Rating _rating = null;

        public IReadOnlyList<Relationship> Relationships => this._relationships;

        [JsonProperty("relations", Required = Required.DisallowNull)]
        private Relationship[] _relationships = null;

        public IReadOnlyList<Release> Releases => this._releases;

        [JsonProperty("releases", Required = Required.DisallowNull)]
        private Release[] _releases = null;

        public IReadOnlyList<Tag> Tags => this._tags;

        [JsonProperty("tags", Required = Required.DisallowNull)]
        private Tag[] _tags = null;

        [JsonProperty("type", Required = Required.Default)]
        public string Type { get; private set; }

        [JsonProperty("type-id", Required = Required.Default)]
        public Guid? TypeId { get; private set; }

        public UserRating UserRating => this._userRating;

        [JsonProperty("user-rating", Required = Required.DisallowNull)]
        private UserRating _userRating = null;

        public IReadOnlyList<UserTag> UserTags => this._userTags;

        [JsonProperty("user-tags", Required = Required.DisallowNull)]
        private UserTag[] _userTags = null;

        #region Search Server Compatibility

        // The search server's serialization differs in the following ways:
        // - the label code is not serialized when not set (instead of being serialized as null)
        // - the disambiguation comment is not serialized when not set (instead of being serialized as an empty string)
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

        // The name is serialized as 'sort-name' too, probably for historical reasons. Ignore it.
#pragma warning disable 169
        [JsonProperty("sort-name")] private string _sortName;
#pragma warning restore 169

    }

}