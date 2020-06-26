using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTowers.Repositories;

namespace WSTowers.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SelecaoController : ControllerBase
    {
        SelecaoRepository _selecaoRepository = new SelecaoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_selecaoRepository.Listar());
        }

        [HttpGet("Completo")]
        public IActionResult ListarCompleto()
        {
            return Ok(_selecaoRepository.ListarCompleto());
        }

        [HttpGet("Nome")]
        public IActionResult ListarPorNome()
        {
            return Ok(_selecaoRepository.ListarPorNome());
        }
    }
}
