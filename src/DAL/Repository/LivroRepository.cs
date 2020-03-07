using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;
using Dapper;
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
                                   l.ISBN, 
                                   a.Nome AS NomeAutor,
                                   CASE WHEN  GeneroId = 0 THEN 'Romance'
                                        WHEN  GeneroId = 1 THEN 'Drama'
                                        ELSE  'Terror'
                                   END AS  NomeGenero                
                                   FROM Livro l
                                   JOIN Autor AS a ON l.AutorId = a.AutorId "
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
            Livro livro = new Livro();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Livro WHERE LivroId =" + livroId;
                    livro = con.Query<Livro>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return livro;
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
                                                    DataPublicacao,
                                                    QtdPaginas
                                                    AutorId,
                                                    EditoriaId,
                                                    Descricao,
                                                    Sinopse,
                                                    ImagemCapa,
                                                    LinksCompra,
                                                    ISBN) 
                                                    VALUES 
                                                    (@Titulo,
                                                     @GeneroId, 
                                                     @DataPublicacao,
                                                     @QtdPaginas
                                                     @AutorId,
                                                     @EditoriaId,
                                                     @Descricao,
                                                     @Sinopse,
                                                     @ImagemCapa,
                                                     @LinksCompra,
                                                     @ISBN); SELECT CAST(SCOPE_IDENTITY() as INT); ";
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
                                                   DataPublicacao = @DataPublicacao,
                                                   QtdPaginas = @QtdPaginas,
                                                   AutorId = @AutorId,
                                                   EditoriaId = @EditoriaId,
                                                   Descricao = @Descricao,
                                                   Sinopse = @Sinopse,
                                                   ImagemCapa = @ImagemCapa,
                                                   LinksCompra = @LinksCompra,
                                                   ISBN = @ISBN
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
