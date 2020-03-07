using BLL.DTO;
using BLL.Models;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ILivroRepository : IRepositoryBase, IDisposable
    {
        int Add(Livro livro);
        int Update(Livro livro);
        int Remove(int livroId);
        List<LivroDTO> GetAll(string pesquisa = "");
        Livro GetById(int livroId);
        bool CheckExistsISBN(int ISBN, int livroId = 0);
    }
}
