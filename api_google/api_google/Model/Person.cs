using api_google.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_google.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("adress")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }

    }
}
