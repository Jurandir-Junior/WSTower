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
    public class JogoController : ControllerBase
    {
        JogosRepository _jogosRepository = new JogosRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_jogosRepository.Listar());
        }

        [HttpGet("Data/{Data}")]
        public IActionResult ListarPorData(string data)
        {
            return Ok(_jogosRepository.ListarPorData(data));
        }

        [HttpGet("Estadio/{Estadio}")]
        public IActionResult ListarPorEstadio(string estadio)
        {
            return Ok(_jogosRepository.ListarPorEstadio(estadio));
        }

        [HttpGet("Selecao/{Nome}")]
        public IActionResult ListarPorSelecao(string nome)
        {
            return Ok(_jogosRepository.ListarPorSelecao(nome));
        }
    }
}
