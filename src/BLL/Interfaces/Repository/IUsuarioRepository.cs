using BLL.DTO;
using BLL.Models;
using System;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBase, IDisposable
    {
        int Add(Usuario usuario);
        int Update(Usuario usuario);
        int Remove(int usuarioId);
        List<UsuarioDTO> GetAll(string pesquisa = "");
       Usuario GetById(int usuarioId);        
    }
}
