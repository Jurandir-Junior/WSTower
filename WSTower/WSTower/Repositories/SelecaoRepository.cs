using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTowers.Repositories
{
    public class SelecaoRepository
    {
        public List<Selecao> Listar()
        {
            using (CampeonatoBDContext ctx = new CampeonatoBDContext())
            {
                //Retorna seleções sem incluir jogadores
                return ctx.Selecao.ToList();
            }
        }

        public List<Selecao> ListarCompleto()
        {
            using (CampeonatoBDContext ctx = new CampeonatoBDContext())
            {
                //Tentativa de selecionar colunas especificas, mas ao executar exige todas as colunas.
                //var query = ctx.Selecao.FromSqlRaw("SELECT s.Nome, s.Bandeira, j.Nome AS JogadorNome, j.Posicao, j.Foto FROM Selecao AS s JOIN Jogador AS j on s.Id = j.SelecaoID").ToList();
                //return query;

                //Retorno Completo
                return ctx.Selecao.Include(s => s.Jogador).ToList();
            }
        }

        public List<Selecao> ListarPorNome()
        {
            using (CampeonatoBDContext ctx = new CampeonatoBDContext())
            {
                return ctx.Selecao.OrderBy(selecao => selecao.Nome).ToList();
            }
        }
    }
}
