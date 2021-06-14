namespace ProtoWeb.Infra.CrossCutting.Net.Traceability
{
    public class Variance
    {
        public string Property { get; set; }
        public string PropertyType { get; set; }
        public object originalValue { get; set; }
        public object updatedValue { get; set; }
    }
}
