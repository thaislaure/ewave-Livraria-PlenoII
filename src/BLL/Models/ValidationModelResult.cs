using System.Collections.Generic;

namespace BLL.Models
{
    public abstract class ValidationModelResult
    {
        public IDictionary<string, string> Notifications { get; set; } = new Dictionary<string, string>();

        public abstract void Validar();
    }
}
