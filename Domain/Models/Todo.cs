

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Todo : BaseEntity
    {
        [Key]
        public int Id { get; set; }
               
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public override string TableName => "todos";
        public override string IdKey => "Id";

        public override string InsertQuery => throw new NotImplementedException();

        public override string UpdateQuery => throw new NotImplementedException();
    }
}
