using System.Security.Principal;

namespace AnimeReview.Models
{
    public class Reviewer
    {
        public int Id { get; set; }

        public  string FullName { get; set; }

        public  string NickName { get; set; }   

        public ICollection<Review> Reviews { get; set; }    

    }
}
