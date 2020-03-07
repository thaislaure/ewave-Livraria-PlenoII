using BLL.DTO;
using BLL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace DAL.Repository
{
    public class EditoraRepository : RepositoryBase, IEditoraRepository
    {
        public List<EditoraDTO> GetAll()
        {
            var connectionString = this.GetConnectionString();
            List<EditoraDTO> editoras = new List<EditoraDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    var query = @"SELECT 
                                   e.EditoraId, 
                                   e.Nome                                   
                                   FROM Editora e ";

                    editoras = con.Query<EditoraDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return editoras;
            }
        }
    }
}
