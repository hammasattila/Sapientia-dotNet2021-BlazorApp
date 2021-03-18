using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Resources;
using System.Text.Json;
using ApiClient.Api;
using ApiClient.Extensions;
using ApiClient.Models;

namespace ApiClient
{
    public class TheMovieDBApiClient : ApiClientBase
    {
        public static string BaseUrl = null;
        public static string ApiKey = null;

        public TheMovieDBApiClient()
        {
            if (string.IsNullOrEmpty(BaseUrl))
            {
                BaseUrl = ConfigurationManager.AppSettings.Get("BaseUrl");
                if (string.IsNullOrEmpty(BaseUrl))
                {
                    throw new NullReferenceException();
                }
            }

            if (string.IsNullOrEmpty(ApiKey))
            {
                ApiKey = ConfigurationManager.AppSettings.Get("ApiKey");
                if(string.IsNullOrEmpty(ApiKey))
                {
                    throw new NullReferenceException();
                }
            }
        }

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

        public MovieCreditsResults GetMovieCredits(int movieId)
        {
            var searchUrl = $"{BaseUrl}/movie/{movieId}/credits?api_key={ApiKey}" +
                $"&language=en-US";

           return Get<MovieCreditsResults>(searchUrl);
        }
    }
}
