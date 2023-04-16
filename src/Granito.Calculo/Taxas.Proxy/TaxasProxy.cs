using Domain.Interfaces.Proxies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxas.Proxy
{
    public class TaxasProxy : ITaxasProxy
    {
        private readonly string _url;

        public TaxasProxy()
        {
            _url = Environment.GetEnvironmentVariable("TAXA_URL");
        }

        public async Task<TaxasDto> GetTaxaAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            HttpResponseMessage response = await client.GetAsync("api/taxas");
            var taxa = JsonConvert.DeserializeObject<TaxasDto>(await response.Content.ReadAsStringAsync());
            return taxa;
        }
    }
}
