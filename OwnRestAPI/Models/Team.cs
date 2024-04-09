using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OwnRestAPI.Models
{
    public class Team
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public int Wins { get; set; }
        [Required]
        public int TeamChampionships { get; set; }
        public string CarName { get; set; }
        [JsonIgnore]
        public ICollection<Driver> Drivers { get; set; }
    }
}
