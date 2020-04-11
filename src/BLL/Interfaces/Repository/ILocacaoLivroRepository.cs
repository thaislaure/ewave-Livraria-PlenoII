using BLL.DTO;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Repository
{
    public interface ILocacaoLivroRepository : IRepositoryBase
    {
        int Add(LocacaoLivro locacaolivro);
        int Update(LocacaoLivro locacaolivro);
        int Remove(int livroId);
        List<LocacaoLivroDTO> GetAll(string pesquisa = "");
        LocacaoLivroDTO GetLocaoDTOById(int locacaoId);
        List<LivroDTO> GetAllLivro(bool editando);
        LocacaoLivro GetById(int locacaoId);
        int RetornaQuantidadeLivroEmprestimo(int usuarioId);
        bool CheckQuantidadeDiasLivroEmprestimo(int livroId, int usuarioId);

    }
}