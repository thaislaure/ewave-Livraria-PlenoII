using System;


namespace BLL.Models
{
    public class Livro : ValidationModelResult
    {
        public Livro(int livroId, 
                     string titulo, 
                     int generoId, 
                     int autorId, 
                     string sinopse, 
                     byte[] imagemCapa, 
                     string imagemCapaContentType)
        {
            LivroId = livroId;
            Titulo = titulo;
            GeneroId = generoId;
            AutorId = autorId;
            Sinopse = sinopse;
            ImagemCapa = imagemCapa;
            ImagemCapaContentType = imagemCapaContentType;
        }

        public Livro(string titulo, 
                     int generoId,
                     int autorId,
                     string sinopse,
                     byte[] imagemCapa,
                     string imagemCapaContentType)
        {            
            Titulo = titulo;
            GeneroId = generoId;
            AutorId = autorId;
            Sinopse = sinopse;
            ImagemCapa = imagemCapa;
            ImagemCapaContentType = imagemCapaContentType;
        }

        public Livro(int livroId)
        {
            LivroId = livroId;
        }

        public int LivroId { get; private set; }
        public string Titulo { get; private set; }
        public int GeneroId { get; private set; }
        public int AutorId { get; private set; }
        public string Sinopse { get; private set; }
        public byte[] ImagemCapa { get; private set; }
        public string ImagemCapaContentType { get; private set; }

        

        public void SetarIdentificador(int livroId)
        {
            LivroId = livroId;
        }

        public bool IsValid { get; private set; } = false;

        private void ValidarTitulo()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
                this.Notifications.Add(nameof(Titulo), "Informe o campo Título.");
        }

        private void ValidarGenero()
        {
            if (GeneroId == 0)
                this.Notifications.Add(nameof(GeneroId), "Informe o campo Genero.");
        }

        public override void Validar()
        {
            ValidarTitulo();


            IsValid = this.Notifications.Count == 0;
        }
    }
}
