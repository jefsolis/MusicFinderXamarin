using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Relationship
    {
        public Area Area => this._area;

        [JsonProperty("area", Required = Required.DisallowNull)]
        private Area _area = null;

        public Artist Artist => this._artist;

        [JsonProperty("artist", Required = Required.DisallowNull)]
        private Artist _artist = null;

        [JsonProperty("attributes", Required = Required.DisallowNull)]
        public IReadOnlyList<string> Attributes { get; private set; }

        [JsonProperty("attribute-credits", Required = Required.DisallowNull)]
        public IReadOnlyDictionary<string, string> AttributeCredits { get; private set; }

        [JsonProperty("attribute-values", Required = Required.DisallowNull)]
        public IReadOnlyDictionary<string, string> AttributeValues { get; private set; }

        [JsonProperty("begin", Required = Required.Default)]
        public PartialDate Begin { get; private set; }

        [JsonProperty("direction", Required = Required.Always)]
        public string Direction { get; private set; }

        [JsonProperty("end", Required = Required.Default)]
        public PartialDate End { get; private set; }

        [JsonProperty("ended", Required = Required.DisallowNull)]
        public bool Ended { get; private set; }

        public Event Event => this._event;

        [JsonProperty("event", Required = Required.DisallowNull)]
        private Event _event = null;

        public Instrument Instrument => this._instrument;

        [JsonProperty("instrument", Required = Required.DisallowNull)]
        private Instrument _instrument = null;

        public Label Label => this._label;

        [JsonProperty("label", Required = Required.DisallowNull)]
        private Label _label = null;

        [JsonProperty("ordering-key", Required = Required.DisallowNull)]
        public int? OrderingKey { get; private set; }

        public Place Place => this._place;

        [JsonProperty("place", Required = Required.DisallowNull)]
        private Place _place = null;

        public Recording Recording => this._recording;

        [JsonProperty("recording", Required = Required.DisallowNull)]
        private Recording _recording = null;

        public Release Release => this._release;

        [JsonProperty("release", Required = Required.DisallowNull)]
        private Release _release = null;

        public ReleaseGroup ReleaseGroup => this._releaseGroup;

        [JsonProperty("release_group", Required = Required.DisallowNull)]
        private ReleaseGroup _releaseGroup = null;

        public Series Series => this._series;

        [JsonProperty("series", Required = Required.DisallowNull)]
        private Series _series = null;

        [JsonProperty("source-credit", Required = Required.DisallowNull)]
        public string SourceCredit { get; private set; }

        [JsonProperty("target-credit", Required = Required.DisallowNull)]
        public string TargetCredit { get; private set; }

        [JsonProperty("target-type", Required = Required.DisallowNull)]
        public string TargetTypeText { get; private set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; private set; }

        [JsonProperty("type-id", Required = Required.Default)]
        public Guid? TypeId { get; private set; }

        public Url Url => this._url;

        [JsonProperty("url", Required = Required.DisallowNull)]
        private Url _url = null;

        public Work Work => this._work;

        [JsonProperty("work", Required = Required.DisallowNull)]
        private Work _work = null;

        #region Search Server Compatibility

        // The search server's serialization differs in the following ways:
        // - the begin/end dates and the ended flag are not serialized when not set (instead of being serialized as null/false)
        // - the list of attributes is not serialized when empty (instead of being serialized as an empty array)
        // - the attribute values are not serialized
        // - the source/target credits are not serialized
        // - the target type is not serialized (so the Target property does not work)
        // - the type ID is not serialized
        // => Adjusted the Required flags for affected properties (to allow their omission).

        #endregion

        //public override string ToString() => $"{this.Type} → {this.TargetType}: {this.Target}";

    }

}