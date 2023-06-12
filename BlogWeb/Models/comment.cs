using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWeb.Models
{
    
    public class comment
    {

        
        public Post? post { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        
        [Column(Order = 1)]
        public int? Id { get; set; }

        
        [Column(Order = 2)]
        public string? ApplicationUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? cmt { get; set; }
    }
}
