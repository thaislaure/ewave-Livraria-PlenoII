using BLL.Interfaces;
using BLL.Interfaces.BLL;
using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TesteLivraria
{
    [TestClass]
    public class LivroServiceTests
    {
        private readonly ILivroBLL _livroBLL;

        [TestMethod]
        public void SalvarLivro()
        {
            var livro = this.CriarLivroValido(); 
 
            var retorno = _livroBLL.Add(livro);

            var esperado = true;
            var atual = retorno.Success ;

            Assert.AreEqual(esperado, atual, "Metodo salvar é válido, mas foi considerado inválido");
        }

        [TestMethod]
        public void SalvarLivroInvalido()
        {
            var livro = this.CriarLivroInvalido();

            var retorno = _livroBLL.Add(livro);

            var esperado = true;
            var atual = retorno.Success;

            Assert.AreEqual(esperado, atual, "Metodo salvar é inválido, mas foi considerado válido");
        }

        [TestMethod]
        public void AtualizarLivro()
        {
            var livro = this.CriarLivroValido();
            livro.SetarIdentificador(1);

            var retorno = _livroBLL.Update(livro);

            var esperado = true;
            var atual = retorno.Success;

            Assert.AreEqual(esperado, atual, "Metodo atualizar é válido, mas foi considerado inválido");
        }

        [TestMethod]
        public void DeletarLivro()
        {
            var retorno = _livroBLL.Remove(1);

            var esperado = true;
            var atual = retorno;

            Assert.AreEqual(esperado, atual, "Metodo Deletar é válido, mas foi considerado inválido");

        }

        public Livro CriarLivroValido()
        {
            var livro = new Livro("Eles",
                1,
                1,
                "O que deveria ser um dia festivo, durante a promoção de aniversário de uma loja de doces, se transforma em caos quando criaturas atraídas pela reflexão da luz invadem a pequena e interiorana cidade de Santa Clara da Paciência, durante o verão de 1994.",
                new byte[100],
                "jpg"
                );
            return livro;
        }

        public Livro CriarLivroInvalido()
        {
            var livro = new Livro("Eles",
                0,
                1,
                "O que deveria ser um dia festivo, durante a promoção de aniversário de uma loja de doces, se transforma em caos quando criaturas atraídas pela reflexão da luz invadem a pequena e interiorana cidade de Santa Clara da Paciência, durante o verão de 1994.",
                new byte[100],
               "jpg"
              );
            return livro;
        }
    }
}
