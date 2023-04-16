using Domain.Commands;
using Domain.Dtos;
using Domain.Interfaces.Proxies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandlers
{
    public class CalculaJurosCommandHandler : IRequestHandler<CalculaJurosCommand, CalculoResponseDto>
    {
        private readonly ITaxasProxy _taxasProxy;

        public CalculaJurosCommandHandler(ITaxasProxy taxasProxy)
        {
            _taxasProxy = taxasProxy;
        }

        public async Task<CalculoResponseDto> Handle(CalculaJurosCommand request, CancellationToken cancellationToken)
        {
            var taxa = await _taxasProxy.GetTaxaAsync();

            return new CalculoResponseDto()
            {
                Taxa = taxa.Taxa,
                Tempo = request.Tempo,
                ValorInicial = request.ValorInicial,
                ValorTotal = CalculaValorTotal(request.Tempo, request.ValorInicial, taxa.Taxa)
            };
        }
        private decimal CalculaValorTotal(int tempo, decimal valorInicial, decimal taxa)
        {
            var total = Convert.ToDouble( valorInicial )* Math.Pow((1 + Convert.ToDouble( taxa)),tempo);
            return Math.Round( Convert.ToDecimal(total),2);
        }
    }
}
