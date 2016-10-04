using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmative.Models;
using Xunit;

namespace Filmative.Tests
{
    public class MovieTest
    {
       [Fact]
       public void GetTitleTest()
        {
            var movie = new Movie();
            movie.Title = "Tron";

            var result = movie.Title;

            Assert.Equal("Tron", result);
        }
    }
}
