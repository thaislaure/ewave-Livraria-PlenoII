using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAutorRepository : IRepositoryBase
    {
        List<AutorDTO> GetAll();
    }
}
