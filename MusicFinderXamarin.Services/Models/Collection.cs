using System;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Collection
    {
        [JsonProperty("id", Required = Required.Default)]
        public Guid MbId { get; private set; }

        [JsonProperty("editor", Required = Required.Default)]
        public string Editor { get; private set; }

        [JsonProperty("entity-type", Required = Required.Default)]
        public string ContentTypeText { get; private set; }

        public int ItemCount => this._areaCount
                              + this._artistCount
                              + this._eventCount
                              + this._instrumentCount
                              + this._labelCount
                              + this._placeCount
                              + this._recordingCount
                              + this._releaseCount
                              + this._releaseGroupCount
                              + this._seriesCount
                              + this._workCount;

        [JsonProperty("area-count", Required = Required.Default)] private int _areaCount = 0;
        [JsonProperty("artist-count", Required = Required.Default)] private int _artistCount = 0;
        [JsonProperty("event-count", Required = Required.Default)] private int _eventCount = 0;
        [JsonProperty("instrument-count", Required = Required.Default)] private int _instrumentCount = 0;
        [JsonProperty("label-count", Required = Required.Default)] private int _labelCount = 0;
        [JsonProperty("place-count", Required = Required.Default)] private int _placeCount = 0;
        [JsonProperty("recording-count", Required = Required.Default)] private int _recordingCount = 0;
        [JsonProperty("release-count", Required = Required.Default)] private int _releaseCount = 0;
        [JsonProperty("release-group-count", Required = Required.Default)] private int _releaseGroupCount = 0;
        [JsonProperty("series-count", Required = Required.Default)] private int _seriesCount = 0;
        [JsonProperty("work-count", Required = Required.Default)] private int _workCount = 0;

        [JsonProperty("name", Required = Required.Default)]
        public string Name { get; private set; }

        [JsonProperty("type", Required = Required.Default)]
        public string Type { get; private set; }

        [JsonProperty("type-id", Required = Required.Default)]
        public Guid? TypeId { get; private set; }

        public override string ToString() => $"{this.Name} ({this.Type}) ({this.ItemCount} item(s))";

    }

}