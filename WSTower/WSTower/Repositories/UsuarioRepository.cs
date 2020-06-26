using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;
using WSTowers.Interfaces;

namespace WSTowers.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // OBJETO POR ONDE SERÃO CHAMADOS OS MÉTODOS EF Core
        CampeonatoBDContext ctx = new CampeonatoBDContext();

        /// <summary>
        /// CADASTRA UM NOVO USUÁRIO
        /// </summary>
        /// <param name="novoUsuario">OBJETO QUE SERÁ CADASTRADO</param>
        public void Cadastrar(Usuario novoUsuario)
        {   
            //ADICIONA UM NOVO USUÁRIO NO BANCO DE DADOS
            ctx.Usuario.Add(novoUsuario);

            // SALVA AS INFORMAÇÕES PARA SEREM GRAVADAS NO BANCO
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario
                .Select(u => new Usuario()
                {   Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    Apelido = u.Apelido,
                    Foto = u.Foto,
                    Senha = u.Senha
                })
                .ToList();
        }

        public void AlterarSenha(Usuario usuario, string novaSenha)
        {
            usuario.Senha = novaSenha;

            ctx.Usuario.Update(usuario);
            ctx.SaveChanges();
        }

        public Usuario BuscarUsuario(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            if(usuarioBuscado.Email != null){
               
                return usuarioBuscado;
            }
            return null;
        }

        public void AlterarDados(Usuario usuarioAtualizado, Usuario novoDado)
        {
            usuarioAtualizado.Nome = novoDado.Nome;
            usuarioAtualizado.Email = novoDado.Email;
            usuarioAtualizado.Apelido = novoDado.Apelido;
            usuarioAtualizado.Foto = novoDado.Foto;

            ctx.Usuario.Update(usuarioAtualizado);

            ctx.SaveChanges();
        }

         public Usuario Login(string login, string senha)
        { 
            
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == login || u.Apelido == login && u.Senha == senha);

            if (usuarioBuscado.Email != null){
                
                if (usuarioBuscado.Email == login || usuarioBuscado.Apelido == login){

                    if (usuarioBuscado.Senha == senha){

                        return usuarioBuscado;
                    }
                    return null;
                }
            }
            return null;
        }       
    }
}
