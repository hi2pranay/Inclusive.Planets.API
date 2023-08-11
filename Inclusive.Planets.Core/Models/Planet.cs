using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inclusive.Planets.Core.Models
{
    public class Planet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }

        public string? PlanetName { get; set; }

        [MaxLength]
        public byte[]? PlanetImage { get; set; }

        public string? PlanetImageTitle { get; set; }

        public double Distance { get; set; }

        public double Mass { get; set; }

        public double Diameter { get; set; }
    }
}
