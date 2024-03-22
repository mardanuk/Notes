using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Domain
{
    [Table("notes")]
    public class Note
    {
        [Key]
        [Column("header")]
        public required string Header { get; set; }

        [Column("text")]
        public required string Text { get; set; }

        [Column("users")]
        public List<User> Users { get; set; } = new List<User>();
    }
}