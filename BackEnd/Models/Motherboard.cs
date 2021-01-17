using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    [Table("Maticna_Ploca")]
    public class Motherboard
    {
        [Key]
        [Column("ID")]
        public int MotherboardID { get; set; }

        [Column("Ime_Maticne")]
        public string maticna { get; set; }

        [Column("Procesor")]
        public string cpu { get; set; }

        [Column("Graficka_Kartica")]
        public string GPU { get; set; }

        [Column("Max_Ram")]
        public int maxRam{get;set;}

        [Column("Broj_Ram_Slota")]
        public int ramSlots { get; set; }

        [Column("Max_Sata")]
        public int maxSATA { get; set; }
        [Column("Max_NVME")]
        public int maxNVME { get; set; }
        
        public virtual List<Memory> Memory{get;set;}
        /*public List<Memory> RAM{get;set;}

        public List<Memory> SATA{get;set;}  

        public List<Memory> NVME{get;set;}*/

        [ForeignKey("PC")]
        public int PCID{get;set;}
        [JsonIgnore]
        public PC PC{get;set;}

    }
}