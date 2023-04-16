using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using MediatR;

namespace Domain.Commands
{
    public class CalculaJurosCommand : IRequest<CalculoResponseDto>
    {
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }

    }
}
