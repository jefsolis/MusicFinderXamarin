using System;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Alias
    {
        //[JsonProperty("begin", Required = Required.Default)]
        //public PartialDate Begin { get; private set; }

        //[JsonProperty("end", Required = Required.Default)]
        //public PartialDate End { get; private set; }

        [JsonProperty("ended", Required = Required.Default)]
        public bool Ended { get; private set; }

        [JsonProperty("locale", Required = Required.Default)]
        public string Locale { get; private set; }

        [JsonProperty("name", Required = Required.Default)]
        public string Name { get; private set; }

        [JsonProperty("primary", Required = Required.Default)]
        public bool? Primary { get; private set; }

        [JsonProperty("sort-name", Required = Required.Default)]
        public string SortName { get; private set; }

        [JsonProperty("type", Required = Required.Default)]
        public string Type { get; private set; }

        [JsonProperty("type-id", Required = Required.Default)]
        public Guid? TypeId { get; private set; }

        #region Search Server Compatibility

        // The search server's serialization differs in the following ways:
        // - use of 'begin-date' instead of 'begin'
        // - use of 'end-date' instead of 'end'
        // => Adjusted the Required flags for affected properties (to allow their omission).
        // => Added setter-only properties for the search server's names.

        /*[JsonProperty("begin-date", Required = Required.Default)]
        private PartialDate SearchBeginDate
        {
            set { this.Begin = value; }
        }

        [JsonProperty("end-date", Required = Required.Default)]
        private PartialDate SearchEndDate
        {
            set { this.Begin = value; }
        }*/

        #endregion

        public override string ToString()
        {
            var text = this.Name;
            if (!string.IsNullOrEmpty(this.Type))
                text += " (" + this.Type + ")";
            return text;
        }

    }

}