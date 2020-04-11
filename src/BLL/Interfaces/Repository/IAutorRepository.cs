using BLL.DTO;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IAutorRepository : IRepositoryBase
    {
        List<AutorDTO> GetAll();
    }
}
