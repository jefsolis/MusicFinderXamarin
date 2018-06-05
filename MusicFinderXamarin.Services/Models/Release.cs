using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    public sealed class ReleaseList
    {
        [JsonProperty("releases", Required = Required.Default)]
        public List<Release> Releases { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Release
    {
        [JsonProperty("id", Required = Required.Default)]
        public Guid MbId { get; private set; }

        public IReadOnlyList<Alias> Aliases => this._aliases;

        [JsonProperty("aliases", Required = Required.Default)]
        private Alias[] _aliases = null;

        [JsonProperty("annotation", Required = Required.Default)]
        public string Annotation { get; private set; }

        public IReadOnlyList<NameCredit> ArtistCredit => this._artistCredit;

        [JsonProperty("artist-credit", Required = Required.Default)]
        private NameCredit[] _artistCredit = null;

        [JsonProperty("asin", Required = Required.Default)]
        public string Asin { get; private set; }

        [JsonProperty("barcode", Required = Required.Default)]
        public string BarCode { get; private set; }

        public IReadOnlyList<Collection> Collections => this._collections;

        [JsonProperty("collections", Required = Required.Default)]
        private Collection[] _collections = null;

        [JsonProperty("country", Required = Required.Default)]
        public string Country { get; private set; }

        public CoverArtArchive CoverArtArchive => this._coverArtArchive;

        [JsonProperty("cover-art-archive", Required = Required.Default)]
        private CoverArtArchive _coverArtArchive = null;

        private string _cover;
        public string CoverArtUrl {
            get
            {
                return _cover;
            }
            set
            {
                _cover = value.Replace("\"", "");
            }
        }

        [JsonProperty("date", Required = Required.Default)]
        public PartialDate Date { get; private set; }

        [JsonProperty("disambiguation", Required = Required.Default)]
        public string Disambiguation { get; private set; }

        public IReadOnlyList<LabelInfo> LabelInfo => this._labelInfo;

        [JsonProperty("label-info", Required = Required.Default)]
        private LabelInfo[] _labelInfo = null;

        public IReadOnlyList<Medium> Media => this._media;

        [JsonProperty("media", Required = Required.Default)]
        private Medium[] _media = null;

        [JsonProperty("packaging", Required = Required.Default)]
        public string Packaging { get; private set; }

        [JsonProperty("packaging-id", Required = Required.Default)]
        public Guid? PackagingId { get; private set; }

        [JsonProperty("quality", Required = Required.Default)]
        public string Quality { get; private set; }

        public IReadOnlyList<Relationship> Relationships => this._relationships;

        [JsonProperty("relations", Required = Required.Default)]
        private Relationship[] _relationships = null;

        public IReadOnlyList<ReleaseEvent> ReleaseEvents => this._releaseEvents;

        [JsonProperty("release-events", Required = Required.Default)]
        private ReleaseEvent[] _releaseEvents = null;

        public ReleaseGroup ReleaseGroup => this._releaseGroup;

        [JsonProperty("release-group", Required = Required.Default)]
        private ReleaseGroup _releaseGroup = null;

        [JsonProperty("status", Required = Required.Default)]
        public string Status { get; private set; }

        [JsonProperty("status-id", Required = Required.Default)]
        public Guid? StatusId { get; private set; }

        public IReadOnlyList<Tag> Tags => this._tags;

        [JsonProperty("tags", Required = Required.Default)]
        private Tag[] _tags = null;

        public TextRepresentation TextRepresentation => this._textRepresentation;

        [JsonProperty("text-representation", Required = Required.Default)]
        private TextRepresentation _textRepresentation = null;

        [JsonProperty("title", Required = Required.Default)]
        public string Title { get; private set; }

        public IReadOnlyList<UserTag> UserTags => this._userTags;

        [JsonProperty("user-tags", Required = Required.Default)]
        private UserTag[] _userTags = null;

        #region Search Server Compatibility

        // The search server's serialization differs in the following ways:
        // - the barcode is not always serialized (but sometimes serialized as empty string)
        // - the disambiguation comment is not serialized when not set (instead of being serialized as an empty string)
        // - the packaging is not serialized when not set (instead of being serialized as an empty string)
        // - the packaging ID is not serialized
        // - the quality is not serialized
        // - the status ID is not serialized
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
            return text;
        }

    }

}