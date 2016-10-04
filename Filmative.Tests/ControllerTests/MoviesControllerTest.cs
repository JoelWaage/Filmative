using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filmative.Controllers;
using Filmative.Models;
using Xunit;

namespace Filmative.Tests.ControllerTests
{
    public class MoviesControllerTest
    {
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            MoviesController controller = new MoviesController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ModelList_Index_Test()
        {
            ViewResult indexView = new MoviesController().Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsType<List<Movie>>(result);
        }

        [Fact]
        public void Post_MethodAddsMovie_Test()
        {
            MoviesController controller = new MoviesController();
            Movie testMovie = new Movie();
            testMovie.Title = "test movie";

            controller.Create(testMovie);
            ViewResult indexView = new MoviesController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Movie>;

            Assert.Contains<Movie>(testMovie, collection);
        }
    }
}
