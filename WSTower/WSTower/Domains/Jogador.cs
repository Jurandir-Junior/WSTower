using System;
using System.Collections.Generic;

namespace WSTower.Domains
{
    public partial class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Posicao { get; set; }
        public int Qtdefaltas { get; set; }
        public int QtdecartoesAmarelo { get; set; }
        public int QtdecartoesVermelho { get; set; }
        public int Qtdegols { get; set; }
        public string Informacoes { get; set; }
        public int NumeroCamisa { get; set; }
        public byte[] Foto { get; set; }
        public int? SelecaoId { get; set; }

        public virtual Selecao Selecao { get; set; }
    }
}
