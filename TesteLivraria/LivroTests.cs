using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteLivraria
{
    [TestClass]
    public class LivroTests
    {
        [TestMethod]
        public void CriarLivroValido()
        {
            var livro = new Livro("Eles",
               1,
               1,
               "O que deveria ser um dia festivo, durante a promoção de aniversário de uma loja de doces, se transforma em caos quando criaturas atraídas pela reflexão da luz invadem a pequena e interiorana cidade de Santa Clara da Paciência, durante o verão de 1994.",
               new byte[0],
               "jpg"
               );

            livro.Validar();

            var esperado = true;
            var atual = livro.IsValid;

            var result = livro.Notifications;

            Assert.AreEqual(esperado, atual, "Livro é válido, mas foi criado como inválido");
        }

        [TestMethod]
        public void CriarLivroInvalidoAutorInexistente()
        {
            var livro = new Livro("Eles",
                 1,
                 0,
                 "O que deveria ser um dia festivo, durante a promoção de aniversário de uma loja de doces, se transforma em caos quando criaturas atraídas pela reflexão da luz invadem a pequena e interiorana cidade de Santa Clara da Paciência, durante o verão de 1994.",
                 new byte[100],
                 "jpg"
                 );

            livro.Validar();

            var esperado = true;
            var atual = livro.IsValid;

            Assert.AreEqual(esperado, atual, "Livro inválido, Autor não cadastrado");
        }

    

        [TestMethod]
        public void CriarLivroInvalidoGeneroInexistente()
        {
            var livro = new Livro("Eles",
                 0,
                 1,
                 "O que deveria ser um dia festivo, durante a promoção de aniversário de uma loja de doces, se transforma em caos quando criaturas atraídas pela reflexão da luz invadem a pequena e interiorana cidade de Santa Clara da Paciência, durante o verão de 1994.",
                 new byte[100],
                 "jpg"
                 );

            livro.Validar();

            var esperado = true;
            var atual = livro.IsValid;

            Assert.AreEqual(esperado, atual, "Livro inválido, Genero não cadastrado");
        }

    }
}
