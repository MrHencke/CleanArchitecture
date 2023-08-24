using ProjectName.Abstractions.Common;

namespace ProjectName.Database.Abstractions.Entities
{
    public class ExampleEntity : Auditable
    {
        public Guid Id { get; set; }
        public string ExampleValue1 { get; set; }
        public int ExampleValue2 { get; set; }
        public bool ExampleValue3 { get; set; }
    }
}
