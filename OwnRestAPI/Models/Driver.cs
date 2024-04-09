using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OwnRestAPI.Models
{
    public class Driver
    {
        [Key]
        public string Name { get; set; }
        [JsonIgnore]
        public Team Team { get; set; }
        [ForeignKey("Team")]
        public string TeamName { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public int Wins { get; set; }
        [Required]
        public int Podiums { get; set; }
        [Required]
        public int Titles { get; set; }
    }
}
