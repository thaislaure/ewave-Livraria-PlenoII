using BLL.DTO;
using BLL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces.BLL
{
    public interface ILocacaoLivroBLL
    {
        public ValidationResultDTO Add(LocacaoLivro locacaolivro);

        public ValidationResultDTO Update(LocacaoLivro locacaolivro);
        public int Remove(int livroId);

        public List<LocacaoLivroDTO> GetAll(string pesquisa = "");

        public LocacaoLivroDTO GetLocaoDTOById(int locacaoId);

        public LocacaoLivro GetById(int locacaoId);

        public IEnumerable<SelectListItem> GetAllUsuario();

        public IEnumerable<SelectListItem> GetAllLivro(bool editando);

        public bool CheckQuantidadeDiasLivroEmprestimo(int livroId, int usuarioId);

        public int RetornaQuantidadeLivroEmprestimo(int usuarioId);
    }
}
