using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TheMovieDBApiClient.Api;
using TheMovieDBApiClient.Extensions;
using TheMovieDBApiClient.Models;

namespace TheMovieDBApiClient
{
    public class TheMovieDBApiClient : ApiClient
    {
        public static string BaseUrl = "https://api.themoviedb.org/3";
        public static string ApiKey = "";

        public List<Models.Movie> Search(string searchQuery)
        {
            var searchUrl = $"{BaseUrl}/search/movie?api_key={ApiKey}" +
                $"&language=en-US" +
                $"&query={searchQuery}" +
                $"&page=1" +
                $"&include_adult=true";

            var searchResult = Get<SearchResult>(searchUrl);

            var movies = searchResult.ToMovies();

            return movies;
        }
        public MovieDetailResult GetMovieDetail(int movieId)
        {
            var searchUrl = $"{BaseUrl}/movie/{movieId}?api_key={ApiKey}" +
                $"&language=en-US";
            
            return Get< MovieDetailResult>(searchUrl);
        }

        public MovieTrailersResluts GetMovieTrailers(int movieId)
        {
            var searchUrl = $"{BaseUrl}/movie/{movieId}/videos?api_key={ApiKey}" +
                $"&language=en-US";

            return Get<MovieTrailersResluts>(searchUrl);
        }
    }
}
