using System;
using System.Collections.Generic;

namespace WSTower.Domains
{
    public partial class Selecao
    {
        public Selecao()
        {
            Jogador = new HashSet<Jogador>();
            JogoSelecaoCasaNavigation = new HashSet<Jogo>();
            JogoSelecaoVisitanteNavigation = new HashSet<Jogo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Bandeira { get; set; }
        public byte[] Uniforme { get; set; }
        public string Escalacao { get; set; }

        public virtual ICollection<Jogador> Jogador { get; set; }
        public virtual ICollection<Jogo> JogoSelecaoCasaNavigation { get; set; }
        public virtual ICollection<Jogo> JogoSelecaoVisitanteNavigation { get; set; }
    }
}
