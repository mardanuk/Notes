using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Domain
{
    [Table("users")]
    internal class User
    {
        [Key]
        [Column("login")]
        public required string Login { get; set; }

        [Column("name")]
        public required string Name { get; set; }
    }
}
