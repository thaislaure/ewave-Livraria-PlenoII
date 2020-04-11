using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class LivroViewModel
    {        
        [DisplayName("Código")]
        public int LivroId { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "O campo {0} é requerido.", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "O Título deve ter entre 2 e 200 caracteres.", MinimumLength = 2)]
        public string Titulo { get; set; }

        [DisplayName("Gênero")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public int GeneroId { get; set; }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        public int AutorId { get; set; }
                
        [DisplayName("Sinopse")]
        [Required(ErrorMessage = "O campo {0} é requerido.", AllowEmptyStrings = false)]
        [StringLength(1000, ErrorMessage = "A Sinopse deve ter entre 2 e 1000 caracteres.", MinimumLength = 2)]
        public string Sinopse { get; set; }
        
        [DisplayName("Imagem da capa")]
        public byte[] ImagemCapa { get; set; }

        public string ImagemCapaContentType { get; set; }
    }
}
