using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    public class CodeController : ControllerBase
    {
        [HttpGet]
        [Route("show-me-the-code")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShowCodeDto))]
        public async Task<IActionResult> Index()
        {
            return Ok(new ShowCodeDto()
            {
                UrlGitCalculo = "https://github.com/Pablo1402/granito-calculo",
                UrlGitTaxa= "https://github.com/Pablo1402/granito-taxas"
            });
        }


    }

    
}
