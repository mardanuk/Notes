using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Domain
{
    [Table("notes")]
    public class Note
    {
        [Column("header")]
        [Key]
        public required string Header { get; set; }
        [Column("text")]
        public required string Text { get; set; }
    }
}