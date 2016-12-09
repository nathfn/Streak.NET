namespace Streak.Net.Api.Enums
{
    public class FieldType
    {
            private FieldType(string value) { Value = value; }
            public string Value { get; set; }
            public static FieldType TextInput => new FieldType("TEXT_INPUT");
            public static FieldType Person => new FieldType("PERSON");
            public static FieldType Date => new FieldType("DATE");
    }
}
