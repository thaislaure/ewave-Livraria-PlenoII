using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;
using Dapper;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Repository
{
    public class InstituicaoRepository : RepositoryBase, IInstituicaoRepository
    {        
        public List<InstituicaoDTO> GetAll()
        {
            var connectionString = this.GetConnectionString();
            List<InstituicaoDTO> instituicoes = new List<InstituicaoDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();                                      

                    var query = @"SELECT 
                                   i.InstituicaoId, 
                                   i.Nome                                   
                                   FROM Instituicao i ";

                    instituicoes = con.Query<InstituicaoDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return instituicoes;
            }
        }

        public List<InstituicaoDTO> GetAll(string pesquisa = "")
        {
            var connectionString = this.GetConnectionString();
            List<InstituicaoDTO> instituicao = new List<InstituicaoDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    if (!string.IsNullOrWhiteSpace(pesquisa))
                        where = " l.Titulo Like '%" + pesquisa + "%' OR a.Nome Like '%" + pesquisa + "%' ";

                    var query = @"SELECT 
                                   i.InstituicaoId, 
                                   i.Nome 
                                   FROM Instituicao i "
                                  + where;

                    instituicao = con.Query<InstituicaoDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return instituicao;
            }
        }

        public Instituicao GetById(int instituicaoId)
        {
            var connectionString = this.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Instituicao WHERE InstituicaoId =" + instituicaoId;
                    return con.Query<Instituicao>(query).FirstOrDefault();
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

        public int Add(Instituicao instituicao)
        {
            var connectionString = this.GetConnectionString();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Instituicao(Nome,                                                                                                             
                                                          Endereco,
                                                          CNPJ,
                                                          Telefone) 
                                                          VALUES 
                                                          (@Nome,                                                                                                            
                                                           @Endereco,
                                                           @CNPJ,
                                                           @Telefone); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, instituicao);
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

        public int Update(Instituicao instituicao)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE Instituicao SET Nome = @Nome, 
                                                         Endereco = @Endereco,
                                                         CNPJ = @CNPJ,                                                                                                      
                                                         Telefone = @Telefone
                                 WHERE InstituicaoId = " + instituicao.InstituicaoId;
                    count = con.Execute(query, instituicao);
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

        public int Remove(int instituicaoId)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Instituicao WHERE InstituicaoId =" + instituicaoId;
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
