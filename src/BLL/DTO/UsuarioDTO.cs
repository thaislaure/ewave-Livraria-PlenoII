using System.ComponentModel;

namespace BLL.DTO
{
    public class UsuarioDTO
    {
        [DisplayName("Código")]
        public int UsuarioId { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
