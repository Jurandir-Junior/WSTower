using System;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTowers.Repositories;
using WSTowers.ViewModels;

namespace WSTowers.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private UsuarioRepository _usuarioRepository { get; set; }
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                // BUSCA PELO LOGIN E SENHA 
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Login, login.Senha);
  
                if (usuarioBuscado.Email != null)
                {
                    return Ok("LOGIN REALIZADO");
                } 

            } catch (Exception error) {       
                return BadRequest(new
                {
                    mensagem = "LOGIN OU SENHA INCORRETA. TENTE NOVAMENTE.",
                    error
                });
            }   
            return StatusCode(403, "ACONTECEU UM ERRO INESPERADO. ESTAMOS RESOLVENDO IMEDIATAMENTE.");       
        }
    }
}