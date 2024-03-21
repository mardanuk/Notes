using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Domain
{
    [Table("accesses")]
    internal class Accesses
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Key]
        [Column("header")]
        public required string Header { get; set; }
    }
}
