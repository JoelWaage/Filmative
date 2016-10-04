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
    }
}
