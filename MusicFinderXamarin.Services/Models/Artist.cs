using System;
using System.Collections.Generic;
using Newtonsoft.Json;

//https://github.com/Zastai/MusicBrainz/blob/master/MetaBrainz.MusicBrainz/Objects/Entities/Artist.cs

namespace MusicFinderXamarin.Services
{
    public sealed class ArtistList
    {
        [JsonProperty("artists", Required = Required.Default)]
        public List<Artist> Artists { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Artist
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

        public Area BeginArea => this._beginArea;

        [JsonProperty("begin_area", Required = Required.Default)]
        private Area _beginArea = null;

        [JsonProperty("country", Required = Required.Default)]
        public string Country { get;  set; }

        [JsonProperty("disambiguation", Required = Required.DisallowNull)]
        public string Disambiguation { get; private set; }

        public Area EndArea => this._endArea;

        [JsonProperty("end_area", Required = Required.Default)]
        private Area _endArea = null;

        [JsonProperty("gender", Required = Required.Default)]
        public string Gender { get; private set; }

        [JsonProperty("gender-id", Required = Required.Default)]
        public Guid? GenderId { get; private set; }

        [JsonProperty("ipis", Required = Required.DisallowNull)]
        public IReadOnlyList<string> Ipis { get; private set; }

        [JsonProperty("isnis", Required = Required.DisallowNull)]
        public IReadOnlyList<string> Isnis { get; private set; }

        public LifeSpan LifeSpan => this._lifeSpan;

        [JsonProperty("life-span", Required = Required.DisallowNull)]
        private LifeSpan _lifeSpan = null;

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        public Rating Rating => this._rating;

        [JsonProperty("rating", Required = Required.DisallowNull)]
        private Rating _rating = null;

        public IReadOnlyList<Recording> Recordings => this._recordings;

        [JsonProperty("recordings", Required = Required.DisallowNull)]
        private Recording[] _recordings = null;

        public IReadOnlyList<Relationship> Relationships => this._relationships;

        [JsonProperty("relations", Required = Required.DisallowNull)]
        private Relationship[] _relationships = null;

        public IReadOnlyList<ReleaseGroup> ReleaseGroups => this._releaseGroups;

        [JsonProperty("release-groups", Required = Required.DisallowNull)]
        private ReleaseGroup[] _releaseGroups = null;

        public IReadOnlyList<Release> Releases => this._releases;

        [JsonProperty("releases", Required = Required.DisallowNull)]
        private Release[] _releases = null;

        [JsonProperty("sort-name", Required = Required.AllowNull)]
        public string SortName { get; private set; }

        public IReadOnlyList<Tag> Tags => this._tags;

        [JsonProperty("tags", Required = Required.DisallowNull)]
        private Tag[] _tags = null;

        [JsonProperty("type", Required = Required.Default)]
        public string Type { get;  set; }

        [JsonProperty("type-id", Required = Required.Default)]
        public Guid? TypeId { get; private set; }

        public UserRating UserRating => this._userRating;

        [JsonProperty("user-rating", Required = Required.DisallowNull)]
        private UserRating _userRating = null;

        public IReadOnlyList<UserTag> UserTags => this._userTags;

        [JsonProperty("user-tags", Required = Required.DisallowNull)]
        private UserTag[] _userTags = null;

        public IReadOnlyList<Work> Works => this._works;

        [JsonProperty("works", Required = Required.DisallowNull)]
        private Work[] _works = null;

        #region Search Server Compatibility

        // The search server's serialization differs in the following ways:
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

    }

}