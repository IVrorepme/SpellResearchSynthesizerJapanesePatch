using Mutagen.Bethesda.Skyrim;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpellResearchSynthesizer.Classes
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn, ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SpellInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        private string _Tier = string.Empty;
        [JsonProperty("tier")]
        public string Tier { get => _Tier; set => _Tier = value.ToLower(); }
        [JsonProperty("school")]
        public string School { get; set; } = string.Empty;
        private string _CastingType = string.Empty;

        [JsonProperty("castingType")]
        public string CastingType { get => _CastingType; set => _CastingType = value.ToLower(); }
        [JsonProperty("targeting", ItemConverterType = typeof(AliasedArchetype.Converter))]
        public List<AliasedArchetype> Targeting { get; set; } = new List<AliasedArchetype>();
        [JsonProperty("elements", ItemConverterType = typeof(AliasedArchetype.Converter))]
        public List<AliasedArchetype> Elements { get; set; } = new List<AliasedArchetype>();
        [JsonProperty("techniques", ItemConverterType = typeof(AliasedArchetype.Converter))]
        public List<AliasedArchetype> Techniques { get; set; } = new List<AliasedArchetype>();
        public string SpellID { get; set; } = string.Empty;
        public ISpellGetter? SpellForm { get; set; }
        public string SpellESP => SpellForm == null ? string.IsNullOrEmpty(SpellID) ? "" : SpellID.Split('|')[1] : SpellForm.FormKey.ModKey.FileName.ToString().ToLower();
        public string SpellFormID => SpellForm == null ? string.IsNullOrEmpty(SpellID) ? "" : SpellID.Split('|')[2] : SpellForm.FormKey.ID.ToString("X6").ToLower();

        [JsonProperty("spellId")]
        public string JsonSpellID => $"__formData|{SpellESP}|0x{SpellFormID}";
        private string? tomeID;
        public IBookGetter? TomeForm { get; set; }
        public string? TomeID { get => tomeID?.PadLeft(6).ToLower(); set => tomeID = value?.PadLeft(6).ToLower(); }
        public string? TomeESP => TomeForm == null ? string.IsNullOrEmpty(TomeID) ? null : TomeID.Split('|')[1] : TomeForm.FormKey.ModKey.FileName.ToString().ToLower();
        public string? TomeFormID => TomeForm == null ? string.IsNullOrEmpty(TomeID) ? null : TomeID.Split('|')[2] : TomeForm.FormKey.ID.ToString("X6").ToLower();

        [JsonProperty("tomeId")]
        public string? JsonTomeID => TomeForm == null ? null : $"__formData|{TomeESP}|0x{TomeFormID}";
        public IScrollGetter? ScrollForm { get; set; }
        public string? ScrollID { get; set; }
        public string? ScrollESP => ScrollForm == null ? string.IsNullOrEmpty(ScrollID) ? null : ScrollID.Split('|')[1] : ScrollForm.FormKey.ModKey.FileName.ToString().ToLower();
        public string? ScrollFormID => ScrollForm == null ? string.IsNullOrEmpty(ScrollID) ? null : ScrollID.Split('|')[2] : ScrollForm.FormKey.ID.ToString("X6").ToLower();

        [JsonProperty("scrollId")]
        public string? JsonScrollID => ScrollForm == null ? null : $"__formData|{ScrollESP}|0x{ScrollFormID}";
        [JsonProperty("discoverable")]
        public bool Enabled { get; set; } = true;
        [JsonProperty("hardRemoved")]
        public bool HardRemoved { get; set; } = false;
    }
}