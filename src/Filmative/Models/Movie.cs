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

        public static Movie GetMovie()
        {
            var client = new RestClient("https://omdbapi.com");
            var request = new RestRequest("/?t=how+green+was+my+valley&y=&plot=short&r=json", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var thisMovie = JsonConvert.DeserializeObject<Movie>(jsonResponse["movies"].ToString());
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
