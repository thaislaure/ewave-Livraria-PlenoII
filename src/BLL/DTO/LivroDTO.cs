using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class LivroDTO 
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string NomeGenero { get; set; }
        public DateTime DataPublicacao { get; set; }        
        public string NomeAutor { get; set; }
        public int ISBN { get; set; }
    }
}
