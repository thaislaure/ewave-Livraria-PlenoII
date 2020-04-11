using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Interfaces.BLL;
using Interfaces.Repository;

namespace BLL.Bussiness
{
    public class LivroBLL : ILivroBLL
    {
        private readonly ILivroRepository _repository;
        private readonly IAutorRepository _autorRepository;
        private readonly IGeneroRepository _generoRepository;

        public LivroBLL(ILivroRepository repository,
                        IGeneroRepository generoRepository,
                        IAutorRepository autorRepository)
        {
            _repository = repository;
            _autorRepository = autorRepository;
            _generoRepository = generoRepository;
        }

        public ValidationResultDTO Add(Livro livro)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = _repository.Add(livro);
                validation.AffectedLines = 1;
            }
            

            return validation;
        }

        public ValidationResultDTO Update(Livro livro)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();
            
            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = livro.LivroId;
                validation.AffectedLines = _repository.Update(livro);
            }
            return validation;
        }

        public int Remove(int livroId)
        {            
            return _repository.Remove(livroId);
        }

        public List<LivroDTO> GetAll(string pesquisa = "")
        {
            return _repository.GetAll(pesquisa);
        }

        public Livro GetById(int livroId)
        {
            return _repository.GetById(livroId);
        }

        public IEnumerable<SelectListItem> GetAllGenero()
        {            
            var listaGenerosSelect = new List<SelectListItem>();
            _generoRepository.GetAll().ForEach(item => listaGenerosSelect
            .Add(new SelectListItem 
            {
                Value = item.GeneroId.ToString(),
                Text = item.Nome
            }));

            return listaGenerosSelect;
        }

        public IEnumerable<SelectListItem> GetAllAutor()
        {
            var listaAutoresSelect = new List<SelectListItem>();
            _autorRepository.GetAll().ForEach(item => listaAutoresSelect
            .Add(new SelectListItem
            {
                Value = item.AutorId.ToString(),
                Text = item.Nome
            }));

            return listaAutoresSelect;
        }
    }
}
