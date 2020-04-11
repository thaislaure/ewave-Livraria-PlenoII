using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ReservaLocacao : ValidationModelResult
    {
        public int ReservaId { get; private set; }
        public int UsuarioId { get; private set; }
        public DateTime Data { get; private set; }
        public int LivroId { get; private set; }

        public ReservaLocacao(int reservaId, int usuarioId, DateTime data, int livroId)
        {
            ReservaId = reservaId;
            UsuarioId = usuarioId;
            Data = data;
            LivroId = livroId;
        }

        public ReservaLocacao(int usuarioId, DateTime data, int livroId)
        {
            UsuarioId = usuarioId;
            Data = data;
            LivroId = livroId;
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
