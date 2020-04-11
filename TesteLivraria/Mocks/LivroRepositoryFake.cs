using BLL.DTO;
using BLL.Interfaces.BLL;
using BLL.Models;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteLivraria.Mocks
{
    public class LivroRepositoryFake : ILivroRepository
    {
        private readonly List<Livro> BD;

          private readonly ILivroBLL _livroBLL;

        public LivroRepositoryFake()
        {
            this.BD = new List<Livro>();
            this.PopulateBD();
        }

        public void Dispose()
        {
            this.BD.Clear();
        }

        public bool CheckExistsISBN(int ISBN, int livroId = 0)
        {
            throw new NotImplementedException();
        }

        public int Add(Livro livro)
        {
            this.BD.Add(livro);

            livro.SetarIdentificador(this.BD.Max(l => l.LivroId) + 1);
            return livro.LivroId;
        }

        public List<LivroDTO> GetAll(string pesquisa = "")
        {
            // return this.BD;
            throw new NotImplementedException();
        }

        public Livro GetById(int livroId)
        {
            return this.BD.FirstOrDefault(l => l.LivroId == livroId);
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public int Remove(int livroId)
        {
            Livro classe =  this.BD.FirstOrDefault(l => l.LivroId == livroId);
            return  this.BD.Remove(classe) == true ? 0 : 1;
        }

        public int Update(Livro livro)
        {
            var livroAntigo = this.BD.FirstOrDefault(l => l.LivroId == livro.LivroId);
            if (livroAntigo != null)
                this.BD.Remove(livroAntigo);


            this.BD.Add(livro);
            return livro.LivroId;
        }


        public void PopulateBD()
        {
            this.Add(
                new Livro("Domain-Driven Design: Atacando as Complexidades no Coração do Software",
                1,
                1,
                 "Com este livro em mãos, desenvolvedores orientados a objetos, analistas de sistema e designers terão a orientação de que precisam para organizar e concentrar seu trabalho, criar modelos de domínio valiosos e úteis, e transformar esses modelos em implementações de software duradouras e de alta qualidade.",
                new byte[100],
                "jpg"));

            this.Add(
               new Livro("Domain-Driven Design: Atacando as Complexidades no Coração do Software",
              2,
              2,
               "Com este livro em mãos, desenvolvedores orientados a objetos, analistas de sistema e designers terão a orientação de que precisam para organizar e concentrar seu trabalho, criar modelos de domínio valiosos e úteis, e transformar esses modelos em implementações de software duradouras e de alta qualidade.",
              new byte[100],
              "jpg"));


        }

    }
}
