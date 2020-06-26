using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTowers.Repositories;

namespace WSTowers.Controllers
{   
    // DEFINE QUE O TIPO DE RESPOSTA DA API SERÁ NO FORMATO JSON
    [Produces("application/json")]

    // DEFINE QUE A ROTA DE UMA REQUISIÇÃO SERÁ NO FORMATO DOMÍNIO/API/CONTROLLER
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // CRIA O OBJETO UsuarioRepository PARA UTILIZAR OS METÓDOS DEFINIDOS NELE
        private UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201, "USUÁRIO CADASTRADO");
        }

        [HttpGet]
        public List<Usuario> GetAll()
        {
            return _usuarioRepository.Listar();
        }

        [HttpPut("{id}")]
        public IActionResult PutKey(int id, Usuario novaSenha)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(id);

            if(usuarioBuscado.Email != null){

                _usuarioRepository.AlterarSenha(usuarioBuscado, novaSenha.Senha);

                return StatusCode(201,"SENHA ALTERADA COM SUCESSO"); 
            }
             return StatusCode(404, "USUÁRIO NÃO ENCONTRADO");
        }

        [HttpPost("{id}")]
        public IActionResult PutData(int id, Usuario novoDado)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(id);

            if(usuarioBuscado.Email != null){
                novoDado.Id = id;
                _usuarioRepository.AlterarDados(usuarioBuscado, novoDado);

                return StatusCode(201,"DADOS ALTERADOS COM SUCESSO"); 
            }
             return StatusCode(404, "USUÁRIO NÃO ENCONTRADO");
        }
        
    }
}
