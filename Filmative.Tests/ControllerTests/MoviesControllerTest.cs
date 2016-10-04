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
                new Movie {MovieId = 1, Title = "Tron" },
                new Movie {MovieId = 2, Title = "Tron: Legacy" },
                new Movie {MovieId = 3, Title = "Mad Max: Beyond Thunderdome" }
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

        [Fact]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
            MoviesController controller = new MoviesController(mock.Object);
            Movie testMovie = new Movie();
            testMovie.Title = "Valley of the Dolls";
            testMovie.MovieId = 1;

            controller.Create(testMovie);
            ViewResult indexView = new MoviesController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Movie>;

            Assert.Contains<Movie>(testMovie, collection);
        }
    }
}
