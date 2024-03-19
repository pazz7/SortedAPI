namespace Sorted.Domain.Rainfall
{
    public class ServiceResponseReading
    {
        public string context { get; set; }
        public Meta meta { get; set; }
        public Item[] items { get; set; }
    }

    public class Meta
    {
        public string publisher { get; set; }
        public string licence { get; set; }
        public string documentation { get; set; }
        public string version { get; set; }
        public string comment { get; set; }
        public string[] hasFormat { get; set; }
        public int limit { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public DateTime dateTime { get; set; }
        public string measure { get; set; }
        public float value { get; set; }
    }
}
