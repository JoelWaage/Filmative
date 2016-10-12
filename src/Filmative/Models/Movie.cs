using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filmative.Models;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Filmative.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Image { get; set; }
        public string Metascore { get; set; }
        public virtual ICollection<Score> Scores { get; set; }

        public override bool Equals(System.Object otherMovie)
        {
            if (!(otherMovie is Movie))
            {
                return false;
            }
            else
            {
                Movie newMovie = (Movie)otherMovie;
                return this.MovieId.Equals(newMovie.MovieId);
            }
        }

        public override int GetHashCode()
        {
            return this.MovieId.GetHashCode();
        }

        public static Movie GetMovie(string title)
        {
            Movie thisMovie = new Movie();

            var client = new RestClient("https://omdbapi.com");
            var request = new RestRequest("/?t=" + title + "&y=&plot=short&r=json", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();


            JObject movieObject = JObject.Parse(response.Content);

            thisMovie.MovieId = 50;
            thisMovie.Title = (string)movieObject["Title"];
            thisMovie.Year = (string)movieObject["Year"];
            thisMovie.Rated = (string)movieObject["Rated"];
            thisMovie.Released = (string)movieObject["Released"];
            thisMovie.Runtime = (string)movieObject["Runtime"];
            thisMovie.Genre = (string)movieObject["Genre"];
            thisMovie.Director = (string)movieObject["Director"];
            thisMovie.Writer = (string)movieObject["Writer"];
            thisMovie.Actors = (string)movieObject["Actors"];
            thisMovie.Plot = (string)movieObject["Plot"];
            thisMovie.Image = (string)movieObject["Poster"];
            thisMovie.Metascore = (string)movieObject["Metascore"];
    
            return thisMovie;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}
