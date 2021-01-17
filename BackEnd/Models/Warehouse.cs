using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    [Table("PC_Warehouse")]
    public class Warehouse
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv {get;set;}

        [Column("Kapacitet")]
        public int N { get; set; }

        public virtual List<PC> Racunari { get; set; }
        
    }
}