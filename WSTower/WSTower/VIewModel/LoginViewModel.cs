using System.ComponentModel.DataAnnotations;

namespace WSTowers.ViewModels
{
    /// <summary>
    /// CLASSE RESPONSÁVEL PELO MODELO DE LOGIN
    /// </summary>
    public class LoginViewModel
    {
        // DEFINE QUE A PROPRIEDADE É OBRIGATÓRIA
        [Required(ErrorMessage = "INFORME O CAMPO DE USUÁRIO")]
        // DEFINE O TIPO DE DADO
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required(ErrorMessage = "INFORME A SENHA")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
