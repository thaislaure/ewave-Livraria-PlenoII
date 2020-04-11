using BLL.DTO;
using BLL.Models;
using Dapper;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Repository
{
    public class LocacaoLivroRepository : RepositoryBase, ILocacaoLivroRepository
    {
        public List<LocacaoLivroDTO> GetAll(string pesquisa = "")
        {
            var connectionString = this.GetConnectionString();
            List<LocacaoLivroDTO> locacoes = new List<LocacaoLivroDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    if (!string.IsNullOrWhiteSpace(pesquisa))
                        where = " l.Titulo Like '%" + pesquisa + "%' OR a.Nome Like '%" + pesquisa + "%' ";

                    var query = @"SELECT                                    
                                   lc.LocacaoId,
                                   l.Titulo AS NomeLivro,
                                   u.Nome AS NomeUsuario,
                                   lc.DataLocacao,                                    
                                   lc.DataEntrega,
                                   lc.Devolvido
                                   FROM LocacaoLivro lc
                                   JOIN Usuario AS u ON u.UsuarioId  = lc.UsuarioId
                                   JOIN Livro   AS l ON l.LivroId    = lc.LivroId
                                   JOIN Autor   AS a ON l.AutorId    = a.AutorId 
                                   JOIN Genero  AS g ON l.GeneroId   = g.GeneroId "
                                  + where;

                    locacoes = con.Query<LocacaoLivroDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return locacoes;
            }
        }

        public LocacaoLivroDTO GetLocaoDTOById(int locacaoId)
        {
            var connectionString = this.GetConnectionString();
            LocacaoLivroDTO locacoes = new LocacaoLivroDTO();            
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    var query = @"SELECT                                   
                                   lc.LocacaoId,
                                   l.Titulo AS NomeLivro                                 
                                   FROM LocacaoLivro lc
                                   JOIN Usuario AS u ON u.UsuarioId  = lc.UsuarioId
                                   JOIN Livro   AS l ON l.LivroId    = lc.LivroId";

                    locacoes = con.Query<LocacaoLivroDTO>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return locacoes;
            }
        }

        public LocacaoLivro GetById(int locacaoId)
        {
            var connectionString = this.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM LocacaoLivro WHERE LocacaoId =" + locacaoId;
                    return con.Query<LocacaoLivro>(query).FirstOrDefault();
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

        /// <summary>
        /// Retorna aspenas livros que não estão emprestados.
        /// Atendendo a regra de indisponibilidade de livros em 
        /// condição de emprestado para o usuário.
        /// </summary>
        /// <returns></returns>
        public List<LivroDTO> GetAllLivro(bool editando)
        {
            var connectionString = this.GetConnectionString();
            List<LivroDTO> livros = new List<LivroDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    if (!editando)
                        where = "WHERE COALESCE(lc.Devolvido, 1) = 1 ";

                    var query = @"SELECT                                    
                                   l.LivroId,
                                   l.Titulo                                   
                                   FROM Livro l
                                   LEFT JOIN LocacaoLivro AS lc ON lc.LivroId  = l.LivroId "
                                   + where;

                    livros = con.Query<LivroDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return livros;
            }
        }

        public int Add(LocacaoLivro locacaolivro)
        {
            var connectionString = this.GetConnectionString();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO LocacaoLivro(DataLocacao, 
                                                           DataEntrega,                                                     
                                                           UsuarioId,                                                                                                        
                                                           LivroId,
                                                           Devolvido,
                                                           DataLiberacao,
                                                           DataDevolucao) 
                                                           VALUES 
                                                          (@DataLocacao,
                                                           @DataEntrega,                                                      
                                                           @UsuarioId,                                                     
                                                           @LivroId,
                                                           @Devolvido,
                                                           @DataLiberacao,
                                                           @DataDevolucao); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, locacaolivro);
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

        public int Update(LocacaoLivro locacaolivro)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE LocacaoLivro SET DataLocacao = @DataLocacao, 
                                                          DataEntrega = @DataEntrega,
                                                          UsuarioId = @UsuarioId,                                                                                                      
                                                          LivroId = @LivroId,
                                                          Devolvido = @Devolvido,
                                                          DataLiberacao = @DataLiberacao,
                                                          DataDevolucao = @DataDevolucao

                                 WHERE LocacaoId = " + locacaolivro.LocacaoId;
                    count = con.Execute(query, locacaolivro);
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

        public int Remove(int LocacaoId)
        {
          var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM LocacaoLivro WHERE LocacaoId =" + LocacaoId;
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
        
       

        public int RetornaQuantidadeLivroEmprestimo(int usuarioId)
        {
            var connectionString = this.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = $"SELECT COUNT(LivroId) FROM LocacaoLivro WHERE UsuarioId = {usuarioId} AND Devolvido = 0 AND DataDevolucao IS NULL";
                    return con.Query<int>(query).FirstOrDefault();
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

        public bool CheckQuantidadeDiasLivroEmprestimo(int livroId, int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
