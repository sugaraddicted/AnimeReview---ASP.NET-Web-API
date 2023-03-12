using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();

        ICollection<Review> GetReviewsByReviewer(int reviewerId);

        Reviewer GetReviewerById(int id);

        bool ReviewerExists(int id);

        bool CreateReviewer(Reviewer reviewer);

        bool UpdateReviewer(Reviewer reviewer); 

        bool DeleteReviewer(Reviewer reviewer);

        bool Save();

    }
}
