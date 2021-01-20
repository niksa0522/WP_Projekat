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
        [MaxLength(30)]
        public string Name { get; set; }

        [Column("Maticna_Ploca")]
        public Motherboard motherboard { get; set; }

        [Column("Kuciste")]
        [MaxLength(100)]
        public string Kuciste { get; set; }

        [Column("Napajanje")]
        [MaxLength(6)]
        public string PSU { get; set; }

        [Column("Cena")]
        [MaxLength(6)]
        public string price{get;set;}

        [JsonIgnore]
        public Warehouse Warehouse{get;set;}

    }
}