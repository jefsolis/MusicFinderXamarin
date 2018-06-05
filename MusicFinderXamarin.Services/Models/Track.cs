using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MusicFinderXamarin.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Track
    {
        [JsonProperty("id", Required = Required.Default)]
        public Guid MbId { get; private set; }

        public IReadOnlyList<NameCredit> ArtistCredit => this._artistCredit;

        [JsonProperty("artist-credit", Required = Required.Default)]
        private NameCredit[] _artistCredit = null;

        [JsonProperty("length", Required = Required.Default)]
        public int? Length { get; private set; }

        [JsonProperty("number", Required = Required.Default)]
        public string Number { get; private set; }

        public Recording Recording => this._recording;

        [JsonProperty("recording", Required = Required.Default)]
        private Recording _recording = null;

        [JsonProperty("title", Required = Required.Default)]
        public string Title { get; private set; }

        public override string ToString()
        {
            var text = string.Empty;
            if (this.Number != null)
                text += $"{this.Number}. ";
            if (this.ArtistCredit != null)
            {
                foreach (var nc in this.ArtistCredit)
                    text += nc.ToString();
                text += " / ";
            }
            text += this.Title;
            if (this.Length.HasValue)
                text += $" ({new TimeSpan(0, 0, 0, 0, this.Length.Value)})";
            return text;
        }

    }

}