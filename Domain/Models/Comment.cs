
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Comment : BaseEntity
    {        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post? Post { get; set; }

        public override string TableName => "comments";

        public override string IdKey => "Id";

        public override string InsertQuery => throw new NotImplementedException();

        public override string UpdateQuery => throw new NotImplementedException();
    }
}
