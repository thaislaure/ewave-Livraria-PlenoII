using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BLL.DTO
{
    public class InstituicaoDTO
    {
        [DisplayName("Código")]
        public int InstituicaoId { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
