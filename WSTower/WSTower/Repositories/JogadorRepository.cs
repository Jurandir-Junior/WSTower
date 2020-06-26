using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTowers.Repositories
{
    public class JogadorRepository
    {
        CampeonatoBDContext ctx = new CampeonatoBDContext();

        //public List<Jogador> ListarInner()
        //{
        //    SqlCommand query = new SqlCommand();
        //    List<Jogador> jogador = new List<Jogador>();
        //    List<Selecao> selecao = new List<Selecao>();


        //        query.CommandText = "SELECT SELECAO.Bandeira, SELECAO.Nome, JOGADOR.Foto, JOGADOR.Posicao, JOGADOR.Nascimento, JOGADOR.NumeroCamisa, JOGADOR.Nome, JOGADOR.Informacoes, JOGADOR.QTDEGols, JOGADOR.QTDECartoesAmarelo, JOGADOR.QTDECartoesVermelho, JOGADOR.QTDEFaltas FROM SELECAO" +
        //        "INNER JOIN JOGADOR" +
        //        "ON SELECAO.Id = JOGADOR.SelecaoId";


        //        SqlDataReader rdr = query.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            Jogador jogador1 = new Jogador();
        //            jogador1.Selecao = new Selecao();

        //            jogador1.Selecao.Bandeira = (byte[])rdr["Bandeira"];
        //            jogador1.Selecao.Nome = (string)rdr["Nome"];
        //            jogador1.Foto = (byte[])rdr["Foto"];
        //            jogador1.Posicao = (string)rdr["Posicao"];
        //            jogador1.Nascimento = (DateTime)rdr["Nascimento"];
        //            jogador1.NumeroCamisa = (int)rdr["NumeroCamisa"];
        //            jogador1.Nome = (string)rdr["Nome"];
        //            jogador1.Informacoes = (string)rdr["Informacoes"];
        //            jogador1.Qtdegols = (int)rdr["QTDEGols"];
        //            jogador1.QtdecartoesAmarelo = (int)rdr["QTDECartoesAmarelho"];
        //            jogador1.QtdecartoesVermelho = (int)rdr["QTDECartoesVermelho"];
        //            jogador1.Qtdefaltas = (int)rdr["[QTDEFaltas"];

        //            jogador.Add(jogador1);
        //        }
        //        return jogador;
        //}

        public List<Jogador> ListarInner()
        {
            return ctx.Jogador.Include(x => x.Selecao).ToList();
        }

        public Jogador buscarJogador(string info)
        {
            Jogador jogadorInfo = ctx.Jogador.Select(j => new Jogador()
            {
                Id = j.Id,
                Foto = j.Foto,
                Posicao = j.Posicao,
                Nome = j.Nome,
                Nascimento = j.Nascimento,
                NumeroCamisa = j.NumeroCamisa,
                Qtdegols = j.Qtdegols,
                QtdecartoesAmarelo = j.QtdecartoesAmarelo,
                QtdecartoesVermelho = j.QtdecartoesVermelho,
                Qtdefaltas = j.Qtdefaltas,
                Informacoes = j.Informacoes,
                SelecaoId = j.SelecaoId,

                Selecao = new Selecao()
                {
                    Bandeira = j.Selecao.Bandeira,
                    Nome = j.Selecao.Nome
                }

            }).FirstOrDefault(j => j.Nome.Contains(info));

        
            return jogadorInfo;
        }

        public List<Jogador> buscarPorSelecao(string selecao)
        {
            using (CampeonatoBDContext ctx = new CampeonatoBDContext())
            {                    
                return ctx.Jogador.Where(x => x.Selecao.Nome.Contains(selecao)).ToList();
            }
        }
    }
}

