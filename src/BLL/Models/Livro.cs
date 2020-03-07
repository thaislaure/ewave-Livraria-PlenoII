using System;

namespace BLL.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int QtdPaginas { get; set; }
        public int AutorId { get; set; }
        public int EditoraId { get; set; }
        public string Descricao { get; set; }
        public string Sinopse { get; set; }
        public byte[] ImagemCapa { get; set; }
        public string LinksCompra { get; set; }
        public int ISBN { get; set; }
    }
}
