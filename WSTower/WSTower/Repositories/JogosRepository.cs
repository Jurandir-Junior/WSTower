using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTowers.Repositories
{
    public class JogosRepository
    {
        public List<Jogo> Listar()
        {
            using (CampeonatoBDContext ctx = new CampeonatoBDContext())
            {
                return ctx.Jogo
                    .Include(x => x.SelecaoCasaNavigation)
                    .Include(x => x.SelecaoVisitanteNavigation)
                    .OrderBy(x => x.Data).ToList();
            }
        }

        public List<Jogo> ListarPorData(string data)
        {
            using (CampeonatoBDContext ctx = new CampeonatoBDContext())
            {
                return ctx.Jogo
                    .Include(x => x.SelecaoCasaNavigation)
                    .Include(x => x.SelecaoVisitanteNavigation).Where(x => x.Data.Value.Date.ToString() == data).ToList();
            }
        }

        public List<Jogo> ListarPorEstadio(string estadio)
        {
            using (CampeonatoBDContext ctx = new CampeonatoBDContext())
            {
                return ctx.Jogo
                    .Include(x => x.SelecaoCasaNavigation)
                    .Include(x => x.SelecaoVisitanteNavigation).Where(x => x.Estadio.Contains(estadio)).ToList();
            }
        }
        //Pesquisar por ID (Opção reserva)
        //public List<Jogo> ListarPorSelecao(int id)
        //{
        //    using (WSTorrersContext ctx = new WSTorrersContext())
        //    {
        //        return ctx.Jogo
        //            .Include(x => x.SelecaoCasaNavigation)
        //            .Include(x => x.SelecaoVisitanteNavigation).Where(x => x.SelecaoCasa == id || x.SelecaoVisitante == id).ToList();
        //    }
        //}

        public List<Jogo> ListarPorSelecao(string nome)
        {
            using (CampeonatoBDContext ctx = new CampeonatoBDContext())
            {
                return ctx.Jogo
                    .Include(x => x.SelecaoCasaNavigation)
                    .Include(x => x.SelecaoVisitanteNavigation).Where(x => x.SelecaoCasaNavigation.Nome == nome || x.SelecaoVisitanteNavigation.Nome == nome).ToList();
            }
        }
    }
}
