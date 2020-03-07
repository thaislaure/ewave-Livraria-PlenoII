using BLL.DTO;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILivroBLL
    {
        ValidationResultDTO Add(Livro livro);        
        ValidationResultDTO Update(Livro livro);
        int Remove(int livroId);
        List<LivroDTO> GetAll(string pesquisa = "");
        Livro GetById(int livroId);
        List<EditoraDTO> GetAllEditora();
        List<AutorDTO> GetAllAutor();
    }
}
