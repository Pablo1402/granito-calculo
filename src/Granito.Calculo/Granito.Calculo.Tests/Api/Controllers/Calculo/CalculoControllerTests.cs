using Domain.Commands;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers;
using Xunit;

namespace Granito.Calculo.Tests.Api.Calculo
{
    public class CalculoControllerTests
    {
        private readonly CalculoController _calculoController;
        private readonly Mock<IMediator> _mediator;

        public CalculoControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _calculoController = new CalculoController(_mediator.Object);
        }

        [Fact]
        public async Task CalcularJuros()
        {
            //arrange
            _mediator.Setup(x => x.Send(new CalculaJurosCommand() { Tempo = 5, ValorInicial = 100 }, new CancellationToken()))
                .ReturnsAsync(new CalculoResponseDto() {Taxa = 0.01M,Tempo=5,ValorInicial=100,ValorTotal=105.1M });

            //act
            var retornoController = await _calculoController.CalcularJuros(new CalculaJurosCommand() { Tempo = 5, ValorInicial = 100 });
            var retorno = (OkObjectResult)retornoController;
            //assert
            Assert.Equal(retorno.StatusCode, 200); 
        }
    }
}
