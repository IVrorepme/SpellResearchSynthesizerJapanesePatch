using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SpellResearchSynthesizer.Classes
{
    public class SpellVisualInfo
    {
        public Dictionary<string, string> LocalizedSpellTier {get; set;} = new Dictionary<string, string>();
        public Dictionary<string, string> LocalizedSpellSchool {get; set;} = new Dictionary<string, string>();

        public static SpellVisualInfo From(string configText)
        {
            Console.WriteLine($"read {configText}");
            SpellVisualInfo config = new();
            JObject data = JObject.Parse(configText);
            if (data == null) return config;
            // SpellTier
            Console.WriteLine($"get LocalizeSpellTier");
            JToken? spellTiers = data["LocalizeSpellTier"];
            if (spellTiers == null) return config;

            foreach (JProperty tier in spellTiers)
            {
                if (!config.LocalizedSpellTier.ContainsKey(tier.Name.ToLower()))
                {
                    config.LocalizedSpellTier[tier.Name.ToLower()] = tier.Value.ToString();
                }
            }

            // SpellSchool
            Console.WriteLine($"get LocalizeSpellSchool");
            JToken? spellSchool = data["LocalizeSpellSchool"];
            if (spellSchool == null) return config;

            foreach (JProperty school in spellSchool)
            {
                if (!config.LocalizedSpellSchool.ContainsKey(school.Name.ToLower()))
                {
                    config.LocalizedSpellSchool[school.Name.ToLower()] = school.Value.ToString();
                }
            }

            return config;
        }
    }
}