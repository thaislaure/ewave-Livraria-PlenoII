using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Bussiness
{
    public class LivroBLL : ILivroBLL
    {
        private readonly ILivroRepository _repository;
        private readonly IAutorRepository _autorRepository;
        private readonly IEditoraRepository _editoraRepository;

        public LivroBLL(ILivroRepository repository,
                        IEditoraRepository editoraRepository,
                        IAutorRepository autorRepository)
        {
            _repository = repository;
            _autorRepository = autorRepository;
            _editoraRepository = editoraRepository;
        }

        public ValidationResultDTO Add(Livro livro)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();
            
            if (_repository.CheckExistsISBN(livro.ISBN))
            {
                validation.Notifications.Add("Código de ISBN Já cadastrado para outro livro.");
            }

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

            if (_repository.CheckExistsISBN(livro.ISBN, livro.LivroId))
            {
                validation.Notifications.Add("Código de ISBN Já cadastrado para outro livro");
            }

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

        public List<EditoraDTO> GetAllEditora()
        {
            return _editoraRepository.GetAll();
        }

        public List<AutorDTO> GetAllAutor()
        {
            return _autorRepository.GetAll();
        }
    }
}
