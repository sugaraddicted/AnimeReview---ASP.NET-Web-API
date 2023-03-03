namespace AnimeReview.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }  
        
        public ICollection<Anime> AnimeList { get; set; }
    }
}
