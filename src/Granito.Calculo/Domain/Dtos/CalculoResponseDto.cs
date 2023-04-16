using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class CalculoResponseDto 
    {
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
        public decimal Taxa { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
