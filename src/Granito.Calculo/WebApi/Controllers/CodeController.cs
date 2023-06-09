﻿using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CodeController : ControllerBase
    {
        [HttpGet]
        [Route("show-me-the-code")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShowCodeDto))]
        public async Task<IActionResult> BuscarGitCode()
        {
            return Ok(new ShowCodeDto()
            {
                UrlGitCalculo = "https://github.com/Pablo1402/granito-calculo",
                UrlGitTaxa= "https://github.com/Pablo1402/granito-taxas"
            });
        }


    }

    
}
