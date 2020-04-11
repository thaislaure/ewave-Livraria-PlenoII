using BLL.DTO;
using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces.BLL
{
    public interface IInstituicaoBLL
    {
        ValidationResultDTO Add(Instituicao instituicao);
        ValidationResultDTO Update(Instituicao instituicao);
        int Remove(int instituicaoId);
        List<InstituicaoDTO> GetAll(string pesquisa = "");
        Instituicao GetById(int instituicaoId);        
    }
}
