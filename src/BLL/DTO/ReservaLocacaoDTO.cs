using System;
using System.ComponentModel;

namespace BLL.DTO
{
    public class ReservaLocacaoDTO
    {
        [DisplayName("Código")]
        public int ReservaId { get;  set; }

        [DisplayName("Usuário")]
        public string UsuarioNome { get; set; }

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Livro")]
        public int LivroNome { get; set; }

    }
}
