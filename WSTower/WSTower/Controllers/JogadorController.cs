using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTowers.Repositories;

namespace WSTowers.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private JogadorRepository _jogadorRepository;
        public JogadorController()
        {
            _jogadorRepository = new JogadorRepository();
        }

        [HttpGet("Selecao/{selecao}")]
        public IActionResult GetBySelecao(string selecao)
        {
            return Ok(_jogadorRepository.buscarPorSelecao(selecao));
        }


        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            try
            {
                Jogador jogadorInfo = _jogadorRepository.buscarJogador(nome);

                if(jogadorInfo != null)
                {
                    return Ok(jogadorInfo);
                }
                return NotFound("Jogador não encontrado");
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
