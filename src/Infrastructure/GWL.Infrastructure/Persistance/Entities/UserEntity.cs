using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWL.Infrastructure.Persistance.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Age")]
        public int Age { get; set; }

        [Column("Gender")]
        public string Gender { get; set; }
    }
}
