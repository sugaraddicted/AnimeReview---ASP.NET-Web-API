namespace AnimeReview.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public ICollection<Anime>? Animes { get; set; }
    }
}
