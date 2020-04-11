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
    public class LivroRepository : RepositoryBase, ILivroRepository
    {              
        public List<LivroDTO> GetAll(string pesquisa)
        {
            var connectionString = this.GetConnectionString();
            List<LivroDTO> livros = new List<LivroDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    if (!string.IsNullOrWhiteSpace(pesquisa))
                        where = " l.Titulo Like '%" + pesquisa + "%' OR a.Nome Like '%" + pesquisa + "%' ";

                    var query = @"SELECT 
                                   l.LivroId, 
                                   l.Titulo,                                    
                                   a.Nome AS NomeAutor,
                                   g.Nome AS NomeGenero                
                                   FROM Livro l
                                   JOIN Autor  AS a ON l.AutorId  = a.AutorId 
                                   JOIN Genero AS g ON l.GeneroId = g.GeneroId "
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

        public Livro GetById(int livroId)
        {
            var connectionString = this.GetConnectionString();            
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Livro WHERE LivroId =" + livroId;
                    return con.Query<Livro>(query).FirstOrDefault();
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

        public int Add(Livro livro)
        {
            var connectionString = this.GetConnectionString();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Livro(Titulo, 
                                                    GeneroId,                                                     
                                                    AutorId,                                                                                                        
                                                    Sinopse,
                                                    ImagemCapa,
                                                    ImagemCapaContentType) 
                                                    VALUES 
                                                    (@Titulo,
                                                     @GeneroId,                                                      
                                                     @AutorId,                                                     
                                                     @Sinopse,
                                                     @ImagemCapa,
                                                     @ImagemCapaContentType); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, livro);
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

        public int Update(Livro livro)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE Livro SET Titulo = @Titulo, 
                                                   GeneroId = @GeneroId,
                                                   AutorId = @AutorId,                                                                                                      
                                                   Sinopse = @Sinopse,
                                                   ImagemCapa = @ImagemCapa,
                                                   ImagemCapaContentType = @ImagemCapaContentType
                                 WHERE LivroId = " + livro.LivroId;
                    count = con.Execute(query, livro);
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

        public int Remove(int livroId)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Livro WHERE LivroId =" + livroId;
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

        public bool CheckExistsISBN(int ISBN, int livroId = 0)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT COUNT(LivroId) FROM Livro WHERE ISBN =" + ISBN;

                    if (livroId > 0)
                        query += " AND LivroId <> " + livroId;
                    
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

                return count > 0;
            }
        }

        public void Dispose()
        {            
            GC.SuppressFinalize(this);
        }
    }
}
