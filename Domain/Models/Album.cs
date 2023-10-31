
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Album : BaseEntity
    {        
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public override string TableName => "albums";

        public override string IdKey => "Id";

        public override string InsertQuery => "INSERT INTO Albums(Title,UserId) VALUES (@Title,@UserId)";

        public override string UpdateQuery => "UPDATE Albums SET Title = @Title, UserId = @UserId WHERE Id = @Id";
    }
}
