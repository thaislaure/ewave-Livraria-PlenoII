using System;

namespace BLL.Models
{
    public class Usuario : ValidationModelResult
    {

        public int UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string CPF { get; private set; }
        public int InstituicaoId { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public bool Bloqueado { get; private set; }

        public Usuario(int usuarioId, string nome, string endereco, string cPF, int instituicaoId, string telefone, string email, bool bloqueado)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Endereco = endereco;
            CPF = cPF;
            InstituicaoId = instituicaoId;
            Telefone = telefone;
            Email = email;
            Bloqueado = bloqueado;
        }

        public Usuario(string nome, string endereco, string cPF, int instituicaoId, string telefone, string email, bool bloqueado)
        {
            Nome = nome;
            Endereco = endereco;
            CPF = cPF;
            InstituicaoId = instituicaoId;
            Telefone = telefone;
            Email = email;
            Bloqueado = bloqueado;
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
