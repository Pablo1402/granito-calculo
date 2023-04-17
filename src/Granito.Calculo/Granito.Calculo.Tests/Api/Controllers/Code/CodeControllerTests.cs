using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using Xunit;

namespace Granito.Calculo.Tests.Api.Controllers.Code
{
    public class CodeControllerTests
    {
        private readonly CodeController _controller;

        public CodeControllerTests()
        {
            _controller = new CodeController();
        }

        [Fact]
        public async Task ValidaBuscarGitCode()
        {
            //arrange

            //act
            var retornoController = await _controller.BuscarGitCode();
            var retorno = (OkObjectResult)retornoController;
            //assert
            Assert.Equal(retorno.StatusCode, 200);
        }
    }
}
