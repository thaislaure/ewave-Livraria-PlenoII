using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class LivroDTO 
    {
        [DisplayName("Código")]
        public int LivroId { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Gênero")]
        public string NomeGenero { get; set; }

        [DisplayName("Autor")]
        public string NomeAutor { get; set; }        
    }
}
