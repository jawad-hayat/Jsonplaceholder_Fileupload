
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User : IdentityUser<int>
    {
        [Key]
        
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Suite { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Lat { get; set; } = string.Empty;
        public string Lng { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CatchPhrase { get; set; } = string.Empty;
        public string Bs { get; set; } = string.Empty;
    }   

}
