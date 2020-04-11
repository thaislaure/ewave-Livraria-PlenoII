using BLL.Interfaces;
using Interfaces.Repository;

namespace DAL.Repository
{
    public  class RepositoryBase : IRepositoryBase
    {
        public string GetConnectionString()
        {
            return "Server=DESKTOP-45PDRJ3;Database=Livraria;User Id=sa;Password=302891;";
        }
    }
}
