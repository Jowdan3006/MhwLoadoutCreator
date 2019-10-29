
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MhwLoadoutCreator.Models
{
    public partial class MonsterApi
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public WelcomeType Type { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("elements")]
        public Element[] Elements { get; set; }

        [JsonProperty("ailments")]
        public Ailment[] Ailments { get; set; }

        [JsonProperty("locations")]
        public Location[] Locations { get; set; }

        [JsonProperty("resistances")]
        public Resistance[] Resistances { get; set; }

        [JsonProperty("weaknesses")]
        public Weakness[] Weaknesses { get; set; }

        [JsonProperty("rewards")]
        public Reward[] Rewards { get; set; }
    }

    public partial class Ailment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("recovery")]
        public Recovery Recovery { get; set; }

        [JsonProperty("protection")]
        public Protection Protection { get; set; }
    }

    public partial class Protection
    {
        [JsonProperty("skills")]
        public Skill[] Skills { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rarity")]
        public long Rarity { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("carryLimit")]
        public long CarryLimit { get; set; }
    }

    public partial class Skill
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class Recovery
    {
        [JsonProperty("actions")]
        public Action[] Actions { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("zoneCount")]
        public long ZoneCount { get; set; }
    }

    public partial class Resistance
    {
        [JsonProperty("element")]
        public Element Element { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }
    }

    public partial class Reward
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("conditions")]
        public Condition[] Conditions { get; set; }
    }

    public partial class Condition
    {
        [JsonProperty("type")]
        public ConditionType Type { get; set; }

        [JsonProperty("subtype")]
        public Subtype? Subtype { get; set; }

        [JsonProperty("rank")]
        public Rank Rank { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("chance")]
        public long Chance { get; set; }
    }

    public partial class Weakness
    {
        [JsonProperty("element")]
        public Element Element { get; set; }

        [JsonProperty("stars")]
        public long Stars { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }
    }

    public enum Action { Dodge };

    public enum Element { Blast, Dragon, Fire, Ice, Paralysis, Poison, Sleep, Stun, Thunder, Water };

    public enum Name { AncientForest, CavernsOfElDorado, ConfluenceOfFates, CoralHighlands, ElderSRecess, Everstream, GreatRavine, RottenVale, WildspireWaste };

    public enum Rank { High, Low };

    public enum Subtype { Back, Body, Forearms, Gold, Head, HeadShell, Hindlegs, Horn, Horns, Silver, Tail, Wings };

    public enum ConditionType { Carve, Investigation, Palico, Plunderblade, Reward, Shiny, Track, Wound };

    public enum WelcomeType { Large, Small };

    public partial class MonsterApi
    {
        public static MonsterApi[] FromJson(string json) => JsonConvert.DeserializeObject<MonsterApi[]>(json, MhwLoadoutCreator.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MonsterApi[] self) => JsonConvert.SerializeObject(self, MhwLoadoutCreator.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
        {
            ActionConverter.Singleton,
            ElementConverter.Singleton,
            NameConverter.Singleton,
            RankConverter.Singleton,
            SubtypeConverter.Singleton,
            ConditionTypeConverter.Singleton,
            WelcomeTypeConverter.Singleton,
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
        };
    }

    internal class ActionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Action) || t == typeof(Action?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "dodge")
            {
                return Action.Dodge;
            }
            throw new Exception("Cannot unmarshal type Action");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Action)untypedValue;
            if (value == Action.Dodge)
            {
                serializer.Serialize(writer, "dodge");
                return;
            }
            throw new Exception("Cannot marshal type Action");
        }

        public static readonly ActionConverter Singleton = new ActionConverter();
    }

    internal class ElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Element) || t == typeof(Element?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "blast":
                    return Element.Blast;
                case "dragon":
                    return Element.Dragon;
                case "fire":
                    return Element.Fire;
                case "ice":
                    return Element.Ice;
                case "paralysis":
                    return Element.Paralysis;
                case "poison":
                    return Element.Poison;
                case "sleep":
                    return Element.Sleep;
                case "stun":
                    return Element.Stun;
                case "thunder":
                    return Element.Thunder;
                case "water":
                    return Element.Water;
            }
            throw new Exception("Cannot unmarshal type Element");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Element)untypedValue;
            switch (value)
            {
                case Element.Blast:
                    serializer.Serialize(writer, "blast");
                    return;
                case Element.Dragon:
                    serializer.Serialize(writer, "dragon");
                    return;
                case Element.Fire:
                    serializer.Serialize(writer, "fire");
                    return;
                case Element.Ice:
                    serializer.Serialize(writer, "ice");
                    return;
                case Element.Paralysis:
                    serializer.Serialize(writer, "paralysis");
                    return;
                case Element.Poison:
                    serializer.Serialize(writer, "poison");
                    return;
                case Element.Sleep:
                    serializer.Serialize(writer, "sleep");
                    return;
                case Element.Stun:
                    serializer.Serialize(writer, "stun");
                    return;
                case Element.Thunder:
                    serializer.Serialize(writer, "thunder");
                    return;
                case Element.Water:
                    serializer.Serialize(writer, "water");
                    return;
            }
            throw new Exception("Cannot marshal type Element");
        }

        public static readonly ElementConverter Singleton = new ElementConverter();
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Ancient Forest":
                    return Name.AncientForest;
                case "Caverns of El Dorado":
                    return Name.CavernsOfElDorado;
                case "Confluence of Fates":
                    return Name.ConfluenceOfFates;
                case "Coral Highlands":
                    return Name.CoralHighlands;
                case "Elder's Recess":
                    return Name.ElderSRecess;
                case "Everstream":
                    return Name.Everstream;
                case "Great Ravine":
                    return Name.GreatRavine;
                case "Rotten Vale":
                    return Name.RottenVale;
                case "Wildspire Waste":
                    return Name.WildspireWaste;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            switch (value)
            {
                case Name.AncientForest:
                    serializer.Serialize(writer, "Ancient Forest");
                    return;
                case Name.CavernsOfElDorado:
                    serializer.Serialize(writer, "Caverns of El Dorado");
                    return;
                case Name.ConfluenceOfFates:
                    serializer.Serialize(writer, "Confluence of Fates");
                    return;
                case Name.CoralHighlands:
                    serializer.Serialize(writer, "Coral Highlands");
                    return;
                case Name.ElderSRecess:
                    serializer.Serialize(writer, "Elder's Recess");
                    return;
                case Name.Everstream:
                    serializer.Serialize(writer, "Everstream");
                    return;
                case Name.GreatRavine:
                    serializer.Serialize(writer, "Great Ravine");
                    return;
                case Name.RottenVale:
                    serializer.Serialize(writer, "Rotten Vale");
                    return;
                case Name.WildspireWaste:
                    serializer.Serialize(writer, "Wildspire Waste");
                    return;
            }
            throw new Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }

    internal class RankConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Rank) || t == typeof(Rank?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "high":
                    return Rank.High;
                case "low":
                    return Rank.Low;
            }
            throw new Exception("Cannot unmarshal type Rank");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Rank)untypedValue;
            switch (value)
            {
                case Rank.High:
                    serializer.Serialize(writer, "high");
                    return;
                case Rank.Low:
                    serializer.Serialize(writer, "low");
                    return;
            }
            throw new Exception("Cannot marshal type Rank");
        }

        public static readonly RankConverter Singleton = new RankConverter();
    }

    internal class SubtypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Subtype) || t == typeof(Subtype?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Back":
                    return Subtype.Back;
                case "Body":
                    return Subtype.Body;
                case "Forearms":
                    return Subtype.Forearms;
                case "Gold":
                    return Subtype.Gold;
                case "Head":
                    return Subtype.Head;
                case "Head Shell":
                    return Subtype.HeadShell;
                case "Hindlegs":
                    return Subtype.Hindlegs;
                case "Horn":
                    return Subtype.Horn;
                case "Horns":
                    return Subtype.Horns;
                case "Silver":
                    return Subtype.Silver;
                case "Tail":
                    return Subtype.Tail;
                case "Wings":
                    return Subtype.Wings;
            }
            throw new Exception("Cannot unmarshal type Subtype");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Subtype)untypedValue;
            switch (value)
            {
                case Subtype.Back:
                    serializer.Serialize(writer, "Back");
                    return;
                case Subtype.Body:
                    serializer.Serialize(writer, "Body");
                    return;
                case Subtype.Forearms:
                    serializer.Serialize(writer, "Forearms");
                    return;
                case Subtype.Gold:
                    serializer.Serialize(writer, "Gold");
                    return;
                case Subtype.Head:
                    serializer.Serialize(writer, "Head");
                    return;
                case Subtype.HeadShell:
                    serializer.Serialize(writer, "Head Shell");
                    return;
                case Subtype.Hindlegs:
                    serializer.Serialize(writer, "Hindlegs");
                    return;
                case Subtype.Horn:
                    serializer.Serialize(writer, "Horn");
                    return;
                case Subtype.Horns:
                    serializer.Serialize(writer, "Horns");
                    return;
                case Subtype.Silver:
                    serializer.Serialize(writer, "Silver");
                    return;
                case Subtype.Tail:
                    serializer.Serialize(writer, "Tail");
                    return;
                case Subtype.Wings:
                    serializer.Serialize(writer, "Wings");
                    return;
            }
            throw new Exception("Cannot marshal type Subtype");
        }

        public static readonly SubtypeConverter Singleton = new SubtypeConverter();
    }

    internal class ConditionTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ConditionType) || t == typeof(ConditionType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "carve":
                    return ConditionType.Carve;
                case "investigation":
                    return ConditionType.Investigation;
                case "palico":
                    return ConditionType.Palico;
                case "plunderblade":
                    return ConditionType.Plunderblade;
                case "reward":
                    return ConditionType.Reward;
                case "shiny":
                    return ConditionType.Shiny;
                case "track":
                    return ConditionType.Track;
                case "wound":
                    return ConditionType.Wound;
            }
            throw new Exception("Cannot unmarshal type ConditionType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ConditionType)untypedValue;
            switch (value)
            {
                case ConditionType.Carve:
                    serializer.Serialize(writer, "carve");
                    return;
                case ConditionType.Investigation:
                    serializer.Serialize(writer, "investigation");
                    return;
                case ConditionType.Palico:
                    serializer.Serialize(writer, "palico");
                    return;
                case ConditionType.Plunderblade:
                    serializer.Serialize(writer, "plunderblade");
                    return;
                case ConditionType.Reward:
                    serializer.Serialize(writer, "reward");
                    return;
                case ConditionType.Shiny:
                    serializer.Serialize(writer, "shiny");
                    return;
                case ConditionType.Track:
                    serializer.Serialize(writer, "track");
                    return;
                case ConditionType.Wound:
                    serializer.Serialize(writer, "wound");
                    return;
            }
            throw new Exception("Cannot marshal type ConditionType");
        }

        public static readonly ConditionTypeConverter Singleton = new ConditionTypeConverter();
    }

    internal class WelcomeTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(WelcomeType) || t == typeof(WelcomeType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "large":
                    return WelcomeType.Large;
                case "small":
                    return WelcomeType.Small;
            }
            throw new Exception("Cannot unmarshal type WelcomeType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WelcomeType)untypedValue;
            switch (value)
            {
                case WelcomeType.Large:
                    serializer.Serialize(writer, "large");
                    return;
                case WelcomeType.Small:
                    serializer.Serialize(writer, "small");
                    return;
            }
            throw new Exception("Cannot marshal type WelcomeType");
        }

        public static readonly WelcomeTypeConverter Singleton = new WelcomeTypeConverter();
    }
}
