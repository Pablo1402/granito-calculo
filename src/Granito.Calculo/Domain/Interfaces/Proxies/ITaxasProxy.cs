using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Proxies
{
    public interface ITaxasProxy
    {
        public Task<TaxasDto> GetTaxaAsync();  
    }

    public class TaxasDto
    {
        public decimal Taxa { get; set; }
    }
}
