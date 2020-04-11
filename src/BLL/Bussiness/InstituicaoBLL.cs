using BLL.DTO;
using BLL.Interfaces.BLL;
using BLL.Models;
using Interfaces.Repository;
using System.Collections.Generic;

namespace BLL.Bussiness
{
    public class InstituicaoBLL : IInstituicaoBLL
    {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoBLL(IInstituicaoRepository instituicaoRepository)
        {
            _instituicaoRepository = instituicaoRepository;
        }

        public ValidationResultDTO Add(Instituicao instituicao)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = _instituicaoRepository.Add(instituicao);
                validation.AffectedLines = 1;
            }
            
            return validation;
        }

        public ValidationResultDTO Update(Instituicao instituicao)
        {
            // Regra de Negocio
            ValidationResultDTO validation = new ValidationResultDTO();

            // Reservado para criar regra negocio

            if (validation.Notifications.Count == 0)
            {
                validation.Id = instituicao.InstituicaoId;
                validation.AffectedLines = _instituicaoRepository.Update(instituicao);
            }
            return validation;
        }

        public int Remove(int instituicaoId)
        {
            return _instituicaoRepository.Remove(instituicaoId);
        }

        public List<InstituicaoDTO> GetAll(string pesquisa = "")
        {
            return _instituicaoRepository.GetAll(pesquisa);
        }

        public Instituicao GetById(int instituicaoId)
        {
            return _instituicaoRepository.GetById(instituicaoId);
        }        
    }
}
