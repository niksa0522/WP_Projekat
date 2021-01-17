using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    [Table("Racunari")]
    public class PC
    {
        [Key]
        [Column("ID")]
        public int PCID { get; set; }

        [Column("Pozicija")]
        public int Poz { get; set; }

        [Column("Ime")]
        public string Name { get; set; }

        [Column("Maticna_Ploca")]
        public Motherboard motherboard { get; set; }

        [Column("Kuciste")]
        public string Kuciste { get; set; }

        [Column("Napajanje")]
        public string PSU { get; set; }

        [Column("Cena")]
        public string price{get;set;}

        [JsonIgnore]
        public Warehouse Warehouse{get;set;}

    }
}