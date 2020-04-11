using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class InstituicaoViewModel
    {

        [DisplayName("Código")]
        public int InstituicaoId { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é requerido.", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "O nome deve ter entre 2 e 200 caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "O campo {0} é requerido.", AllowEmptyStrings = false)]
        [StringLength(500, ErrorMessage = "O nome deve ter entre 2 e 500 caracteres.", MinimumLength = 2)]
        public string Endereco { get; set; }

        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "O campo {0} é requerido.", AllowEmptyStrings = false)]
        [StringLength(14, ErrorMessage = "O nome deve ter 14 caracteres.")]
        public string CNPJ { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessage = "O campo {0} é requerido.", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "O Telefone deve ter entre 15 e 20 caracteres.", MinimumLength = 15)]
        public string Telefone { get; set; }
    }
}
