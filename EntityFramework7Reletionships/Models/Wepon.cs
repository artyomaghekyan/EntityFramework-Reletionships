using System.Text.Json.Serialization;

namespace EntityFramework7Reletionships.Models
{
    public class Wepon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharectarId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }
    }
}
