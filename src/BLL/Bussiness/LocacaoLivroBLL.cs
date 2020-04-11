using BLL.DTO;
using BLL.Interfaces;
using BLL.Interfaces.BLL;
using BLL.Models;
using Interfaces.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Bussiness
{
    public class LocacaoLivroBLL : ILocacaoLivroBLL
    {
        private readonly ILocacaoLivroRepository _locacaoLivroRepository;        
        private readonly IUsuarioRepository _usuarioRepository;

        public LocacaoLivroBLL(ILocacaoLivroRepository locacaoLivroRepository,                               
                               IUsuarioRepository usuarioRepository)
        {
            _locacaoLivroRepository = locacaoLivroRepository;            
            _usuarioRepository = usuarioRepository;
        }

        public ValidationResultDTO Add(LocacaoLivro locacaolivro) 
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if(RetornaQuantidadeLivroEmprestimo(locacaolivro.UsuarioId) > 2)
            {
                validation.Notifications.Add("Usuário excedeu a quantidade permitida de emprestimos.");
            }
            
            if (validation.Notifications.Count == 0)
            {
                validation.Id = _locacaoLivroRepository.Add(locacaolivro);
                validation.AffectedLines = 1;
            }
            
            return validation;
        }

        public ValidationResultDTO Update(LocacaoLivro locacaolivro) 
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio
            if (DateTime.Now > locacaolivro.DataDevolucao)
            {
                locacaolivro.SetarDataLiberacao(DateTime.Now.AddDays(30));
            }

            if (validation.Notifications.Count == 0)
            {
                validation.Id = locacaolivro.LivroId;
                validation.AffectedLines = _locacaoLivroRepository.Update(locacaolivro);
            }


            return validation;
        }
        public int Remove(int livroId)
        {
            return _locacaoLivroRepository.Remove(livroId);
        }

        public List<LocacaoLivroDTO> GetAll(string pesquisa = "") 
        {
            return _locacaoLivroRepository.GetAll(pesquisa);
        }

        public LocacaoLivroDTO GetLocaoDTOById(int locacaoId)
        {
            return _locacaoLivroRepository.GetLocaoDTOById(locacaoId);
        }

        public LocacaoLivro GetById(int locacaoId) 
        {
            return _locacaoLivroRepository.GetById(locacaoId);
        }

        public IEnumerable<SelectListItem> GetAllUsuario() 
        {
            var listaUsuariosSelect = new List<SelectListItem>();
            _usuarioRepository.GetAll().ForEach(item => listaUsuariosSelect
            .Add(new SelectListItem
            {
                Value = item.UsuarioId.ToString(),
                Text = item.Nome
            }));

            return listaUsuariosSelect;
        }

        public IEnumerable<SelectListItem> GetAllLivro(bool editando) 
        {
            var listaLivrosSelect = new List<SelectListItem>();
            _locacaoLivroRepository.GetAllLivro(editando).ForEach(item => listaLivrosSelect
            .Add(new SelectListItem
            {
                Value = item.LivroId.ToString(),
                Text = item.Titulo
            }));

            return listaLivrosSelect;
        }

        public bool CheckQuantidadeDiasLivroEmprestimo(int livroId, int usuarioId) 
        {
            return _locacaoLivroRepository.CheckQuantidadeDiasLivroEmprestimo(livroId, usuarioId);
        }

        public int RetornaQuantidadeLivroEmprestimo(int usuarioId) 
        {
            return _locacaoLivroRepository.RetornaQuantidadeLivroEmprestimo(usuarioId);
        }
    }
}
