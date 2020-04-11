using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;
using Dapper;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {

        public List<UsuarioDTO> GetAll(string pesquisa = "")
        {
            var connectionString = this.GetConnectionString();
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    var query = @"SELECT 
                                   u.UsuarioId, 
                                   u.Nome,
                                   u.CPF
                                   FROM Usuario u ";

                    usuarios = con.Query<UsuarioDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return usuarios;
            }
        }

        public Usuario GetById(int usuarioId)
        {
            var connectionString = this.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Usuario WHERE UsuarioId =" + usuarioId;
                    return con.Query<Usuario>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public int Add(Usuario usuario)
        {
            var connectionString = this.GetConnectionString();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Usuario(Nome, 
                                                      Endereco,                                                     
                                                      CPF,                                                                                                        
                                                      InstituicaoId,
                                                      Telefone,
                                                      Email,
                                                      Bloqueado) 
                                                      VALUES 
                                                     (@Nome,
                                                      @Endereco,                                                      
                                                      @CPF,                                                     
                                                      @Telefone,
                                                      @Email,
                                                      @Bloqueado); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, usuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Update(Usuario usuario)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE Usuario SET Nome = @Nome, 
                                                     Endereco = @Endereco,
                                                     CPF = @CPF,                                                                                                      
                                                     InstituicaoId = @InstituicaoId,
                                                     Telefone = @Telefone,
                                                     Email = @Email,
                                                     Bloqueado = @Bloqueado

                                 WHERE UsuarioId = " + usuario.UsuarioId;
                    count = con.Execute(query, usuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Remove(int usuarioId)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Usuario WHERE UsuarioId =" + usuarioId;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
