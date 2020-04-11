using BLL.DTO;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.Interfaces.BLL
{
    public interface ILivroBLL
    {
        ValidationResultDTO Add(Livro livro);        
        ValidationResultDTO Update(Livro livro);
        int Remove(int livroId);
        List<LivroDTO> GetAll(string pesquisa = "");
        Livro GetById(int livroId);
        IEnumerable<SelectListItem> GetAllGenero();
        IEnumerable<SelectListItem> GetAllAutor();
    }
}
