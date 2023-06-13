using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWeb.Models
{
    
    public class comment
    {

        public Post? post { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }   
        public int? postId { get; set; }
        public string? ApplicationUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? cmt { get; set; }
    }
}
