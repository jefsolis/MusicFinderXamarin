﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Event
    {

        [JsonProperty("id", Required = Required.Default)]
        public Guid MbId { get; private set; }

        public IReadOnlyList<Alias> Aliases => this._aliases;

        [JsonProperty("aliases", Required = Required.Default)]
        private Alias[] _aliases = null;

        [JsonProperty("annotation", Required = Required.Default)]
        public string Annotation { get; private set; }

        public bool Cancelled => this._cancelled.GetValueOrDefault();

        [JsonProperty("cancelled", Required = Required.Default)]
        private bool? _cancelled = null;

        [JsonProperty("disambiguation", Required = Required.Default)]
        public string Disambiguation { get; private set; }

        public LifeSpan LifeSpan => this._lifeSpan;

        [JsonProperty("life-span", Required = Required.Default)]
        private LifeSpan _lifeSpan = null;

        [JsonProperty("name", Required = Required.Default)]
        public string Name { get; private set; }

        public Rating Rating => this._rating;

        [JsonProperty("rating", Required = Required.Default)]
        private Rating _rating = null;

        public IReadOnlyList<Relationship> Relationships => this._relationships;

        [JsonProperty("relations", Required = Required.Default)]
        private Relationship[] _relationships = null;

        [JsonProperty("setlist", Required = Required.Default)]
        public string Setlist { get; private set; }

        public IReadOnlyList<Tag> Tags => this._tags;

        [JsonProperty("tags", Required = Required.Default)]
        private Tag[] _tags = null;

        [JsonProperty("time", Required = Required.Default)]
        public string Time { get; private set; }

        [JsonProperty("type", Required = Required.Default)]
        public string Type { get; private set; }

        [JsonProperty("type-id", Required = Required.Default)]
        public Guid? TypeId { get; private set; }

        public UserRating UserRating => this._userRating;

        [JsonProperty("user-rating", Required = Required.Default)]
        private UserRating _userRating = null;

        public IReadOnlyList<UserTag> UserTags => this._userTags;

        [JsonProperty("user-tags", Required = Required.Default)]
        private UserTag[] _userTags = null;

        #region Search Server Compatibility

        // The search server's serialization differs in the following ways:
        // - the disambiguation comment is not serialized when not set (instead of being serialized as an empty string)
        // - the setlist is not serialized when not set (instead of being serialized as an empty string)
        // - the time is not serialized when not set (instead of being serialized as an empty string)
        // - the type is not serialized when not set (instead of being serialized as null)
        // - the type ID is not serialized
        // => Adjusted the Required flags for affected properties (to allow their omission).
        // - the Cancelled flag is not serialized when not set
        // => Adjusted the Required flags for the property (to allow its omission), and added a nullable backing field.

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