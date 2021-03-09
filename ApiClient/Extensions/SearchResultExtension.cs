using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheMovieDBApiClient.Api;
using TheMovieDBApiClient.Models;

namespace TheMovieDBApiClient.Extensions
{
    static class SearchResultExtension
    {
        public static List<Models.Movie> ToMovies(this SearchResult searchresult)
        {
            //var movies = new List<Movie>();

            //foreach (var resultItem in searchresult.results)
            //{
            //    movies.Add(new Movie()
            //    {
            //        Title = resultItem.title,
            //        Poster = resultItem.poster_path
            //    });
            //}

            List<Models.Movie> movies = searchresult.results.Select(item => new Models.Movie()
            {
                ID = item.id,
                Title = item.title,
                Poster = item.poster_path
            }).ToList();

            return movies;
        }
    }
}
