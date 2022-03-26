using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PizzaGame.Core.Domain;

[JsonConverter(typeof(StringEnumConverter))]
public enum Player
{
    [EnumMember(Value = "A")]
    A = 'A',
    [EnumMember(Value = "B")]
    B = 'B'
}