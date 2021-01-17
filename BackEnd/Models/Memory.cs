using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    public class Memory
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [Column("Velicina")]
        public int Size { get; set; }

        [Column("Tip")]
        public string Type{get;set;}
        
        [JsonIgnore]
        public Motherboard Motherboard{get;set;}


    }
}