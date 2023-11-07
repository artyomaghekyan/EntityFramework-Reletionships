using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework7Reletionships.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BackPack BackPack { get; set; }
        public List<Wepon> Wepon { get; set; }
        public List<Faction> Factions { get; set; }
    }
}
