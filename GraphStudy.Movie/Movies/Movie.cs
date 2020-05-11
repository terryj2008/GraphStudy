﻿using System;

namespace GraphStudy.Movies.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Company { get; set; }
        public int ActorId { get; set; }
        public MovieRating MovieRating { get; set; }
    }
}
