using BLL.DTO;
using BLL.Interfaces;
using Dapper;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace DAL.Repository
{
    public class GeneroRepository : RepositoryBase, IGeneroRepository
    {
        public List<GeneroDTO> GetAll()
        {
            var connectionString = this.GetConnectionString();
            List<GeneroDTO> generos = new List<GeneroDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    var query = @"SELECT 
                                   g.GeneroId, 
                                   g.Nome                                   
                                   FROM Genero g ";

                    generos = con.Query<GeneroDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return generos;
            }
        }
    }
}
