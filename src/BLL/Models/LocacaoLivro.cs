using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class LocacaoLivro : ValidationModelResult
    {
        public int LocacaoId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime? DataLiberacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public bool Devolvido { get; set; }

        public LocacaoLivro()
        { }

        public LocacaoLivro(int locacaoId, DateTime dataLocacao, DateTime dataEntrega, DateTime? dataLiberacao, DateTime? dataDevolucao, int usuarioId, int livroId, bool devolvido)
        {
            LocacaoId = locacaoId;
            DataLocacao = dataLocacao;
            DataEntrega = dataEntrega;
            DataLiberacao = dataLiberacao;
            DataDevolucao = dataDevolucao;
            UsuarioId = usuarioId;
            LivroId = livroId;
            Devolvido = devolvido;
        }

        public LocacaoLivro(DateTime dataLocacao, DateTime dataEntrega, DateTime? dataLiberacao, DateTime? dataDevolucao, int usuarioId, int livroId, bool devolvido)
        {
            DataLocacao = dataLocacao;
            DataEntrega = dataEntrega;
            DataLiberacao = dataLiberacao;
            DataDevolucao = dataDevolucao;
            UsuarioId = usuarioId;
            LivroId = livroId;
            Devolvido = devolvido;
        }

        public void SetarDataLiberacao(DateTime dataLiberacao)
        {
            DataLiberacao = dataLiberacao;
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
