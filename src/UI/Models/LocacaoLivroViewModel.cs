using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class LocacaoLivroViewModel
    {

        [DisplayName("Código")]
        public int LocacaoId { get; set; }

        [DisplayName("Data de Locação")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public DateTime DataLocacao { get; set; }

        [DisplayName("Data de Entrega")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public DateTime DataEntrega { get; set; }

        [DisplayName("Data da Devolução")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public DateTime? DataDevolucao { get; set; }

        [DisplayName("Usuário")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public int UsuarioId { get; set; }

        [DisplayName("Livro")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public int LivroId { get; set; }

        [DisplayName("Livro")]
        public string NomeLivro { get; set; }

    }
}
