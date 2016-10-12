using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filmative.Controllers;
using Filmative.Models;
using Filmative.Models.Repositories;
using Xunit;
using Moq;

namespace Filmative.Tests.ControllerTests
{
    public class MoviesControllerTest
    {
        Mock<IMovieRepository> mock = new Mock<IMovieRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Movies).Returns(new Movie[]
            {
                new Movie {MovieId = 1, Title = "Tron", Year = "1", Rated = "2", Released = "3", Runtime = "4", Genre = "5", Director = "6", Writer = "7", Actors = "8", Plot = "9", Image = "10", Metascore = "11" },
                new Movie {MovieId = 2, Title = "Tron: Legacy", Year = "1", Rated = "2", Released = "3", Runtime = "4", Genre = "5", Director = "6", Writer = "7", Actors = "8", Plot = "9", Image = "10", Metascore = "11"  },
                new Movie {MovieId = 3, Title = "Mad Max: Beyond Thunderdome", Year = "1", Rated = "2", Released = "3", Runtime = "4", Genre = "5", Director = "6", Writer = "7", Actors = "8", Plot = "9", Image = "10", Metascore = "11"  }
            }.AsQueryable());
        }

        [Fact]
        public void Mock_GetViewResult_Index_Test()
        {
            DbSetup();
            MoviesController controller = new MoviesController(mock.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_IndexListOfMovies_Test()
        {
            DbSetup();
            ViewResult indexView = new MoviesController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsType<List<Movie>>(result);
        }
    }
}
