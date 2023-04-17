using Domain.CommandHandlers;
using Domain.Commands;
using Domain.Interfaces.Proxies;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Granito.Calculo.Tests.Domain.CommandHandlers
{
    public class CalculaJurosCommandHandlersTests
    {
        //private readonly Mock _mock;
        private readonly CalculaJurosCommandHandler _handler;
        private readonly Mock<ITaxasProxy> _taxaProxy;

        public CalculaJurosCommandHandlersTests()
        {
            _taxaProxy = new Mock<ITaxasProxy>();
            _handler = new CalculaJurosCommandHandler(_taxaProxy.Object);
        }

        [Fact]
        public async Task ValidaCalculoJuros()
        {
            //arrange
            _taxaProxy.Setup(x => x.GetTaxaAsync()).ReturnsAsync(new TaxasDto() { Taxa = 0.01M});

            //act
            var retornoHandle = await _handler.Handle(new CalculaJurosCommand() {Tempo = 5,ValorInicial =100 },new System.Threading.CancellationToken());

            //assert
            Assert.Equal(retornoHandle.ValorTotal , 105.1M);
        }
    }
}
