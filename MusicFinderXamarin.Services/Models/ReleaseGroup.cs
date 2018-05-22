using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class ReleaseGroup
    {
        [JsonProperty("id", Required = Required.Always)]
        public Guid MbId { get; private set; }

        public IReadOnlyList<Alias> Aliases => this._aliases;

        [JsonProperty("aliases", Required = Required.DisallowNull)]
        private Alias[] _aliases = null;

        [JsonProperty("annotation", Required = Required.Default)]
        public string Annotation { get; private set; }

        public IReadOnlyList<NameCredit> ArtistCredit => this._artistCredit;

        [JsonProperty("artist-credit", Required = Required.DisallowNull)]
        private NameCredit[] _artistCredit = null;

        [JsonProperty("disambiguation", Required = Required.DisallowNull)]
        public string Disambiguation { get; private set; }

        [JsonProperty("first-release-date", Required = Required.Default)]
        public PartialDate FirstReleaseDate { get; private set; }

        [JsonProperty("primary-type", Required = Required.AllowNull)]
        public string PrimaryType { get; private set; }

        [JsonProperty("primary-type-id", Required = Required.Default)]
        public Guid? PrimaryTypeId { get; private set; }

        public Rating Rating => this._rating;

        [JsonProperty("rating", Required = Required.DisallowNull)]
        private Rating _rating = null;

        public IReadOnlyList<Relationship> Relationships => this._relationships;

        [JsonProperty("relations", Required = Required.DisallowNull)]
        private Relationship[] _relationships = null;

        public IReadOnlyList<Release> Releases => this._releases;

        [JsonProperty("releases", Required = Required.DisallowNull)]
        private Release[] _releases = null;

        [JsonProperty("secondary-types", Required = Required.DisallowNull)]
        public IReadOnlyList<string> SecondaryTypes { get; private set; }

        [JsonProperty("secondary-type-ids", Required = Required.DisallowNull)]
        public IReadOnlyList<Guid> SecondaryTypeIds { get; private set; }

        public IReadOnlyList<Tag> Tags => this._tags;

        [JsonProperty("tags", Required = Required.DisallowNull)]
        private Tag[] _tags = null;

        [JsonProperty("title", Required = Required.DisallowNull)]
        public string Title { get; private set; }

        public UserRating UserRating => this._userRating;

        [JsonProperty("user-rating", Required = Required.DisallowNull)]
        private UserRating _userRating = null;

        public IReadOnlyList<UserTag> UserTags => this._userTags;

        [JsonProperty("user-tags", Required = Required.DisallowNull)]
        private UserTag[] _userTags = null;

        #region Search Server Compatibility

        // The search server's serialization differs in the following ways:
        // - the disambiguation comment is not serialized when not set (instead of being serialized as an empty string)
        // - the first release date is not serialized
        // - the primary type ID is not serialized
        // - the secondary types are not serialized when not top-level
        // - the secondary type IDs are not serialized
        // - the title is not serialized when not top-level
        // => Adjusted the Required flags for affected properties (to allow their omission).

        #endregion

        public override string ToString()
        {
            var text = string.Empty;
            if (this.ArtistCredit != null)
            {
                foreach (var nc in this.ArtistCredit)
                    text += nc.ToString();
                text += " / ";
            }
            text += this.Title;
            if (!string.IsNullOrEmpty(this.Disambiguation))
                text += " (" + this.Disambiguation + ")";
            if (!string.IsNullOrEmpty(this.PrimaryType))
                text += " (" + this.PrimaryType + ")";
            return text;
        }

    }

}