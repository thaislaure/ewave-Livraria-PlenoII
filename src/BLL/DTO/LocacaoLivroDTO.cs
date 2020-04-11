using System;
using System.ComponentModel;

namespace BLL.DTO
{
    public class LocacaoLivroDTO
    {
        [DisplayName("Código")]
        public int LocacaoId { get;  set; }

        [DisplayName("Livro")]
        public string NomeLivro { get; set; }

        [DisplayName("Usuário")]
        public string NomeUsuario { get; set; }

        [DisplayName("Data de Locação")]
        public DateTime DataLocacao { get;  set; }

        [DisplayName("Data de Entrega")]
        public DateTime DataEntrega { get;  set; }

        [DisplayName("Devolvido ?")]
        public bool Devolvido { get; set; }
    }
}
