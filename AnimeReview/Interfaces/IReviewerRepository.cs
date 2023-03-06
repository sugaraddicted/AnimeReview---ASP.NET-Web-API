﻿using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();

        ICollection<Review> GetReviewsByReviewer(int reviewerId);

        Reviewer GetReviewerById(int id);

        bool ReviewerExists(int id);

    }
}