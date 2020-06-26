using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;

namespace WSTowers.Interfaces
{
    interface IUsuarioRepository
    {
       void Cadastrar(Usuario novoUsuario);

       List<Usuario> Listar();

       Usuario BuscarUsuario(int id);

       void AlterarSenha(Usuario usuario, string novaSenha);

       void AlterarDados(Usuario usuarioAtualizado, Usuario novoDado);

       Usuario Login(string email, string senha);
    }
}
