namespace ServiceOAuth2.domain.Entities
{
    public class PropertyData
    {
        public string Name { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
        public bool IsQueryWhere { get; set; }
    }
}
