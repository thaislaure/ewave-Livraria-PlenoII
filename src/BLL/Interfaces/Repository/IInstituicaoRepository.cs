using BLL.DTO;
using BLL.Models;
using System;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IInstituicaoRepository : IRepositoryBase, IDisposable
    {
        int Add(Instituicao instituicao);
        int Update(Instituicao instituicao);
        int Remove(int instituicaoId);
        List<InstituicaoDTO> GetAll(string pesquisa = "");
        Instituicao GetById(int instituicaoId);        
    }
}
