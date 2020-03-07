using BLL.DTO;
using BLL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AutorRepository : RepositoryBase, IAutorRepository
    {
        public List<AutorDTO> GetAll()
        {
            var connectionString = this.GetConnectionString();
            List<AutorDTO> autores = new List<AutorDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();                                      

                    var query = @"SELECT 
                                   a.AutorId, 
                                   a.Nome                                   
                                   FROM Autor a ";

                    autores = con.Query<AutorDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return autores;
            }
        }
    }
}
