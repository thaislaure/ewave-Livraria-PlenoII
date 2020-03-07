using System.Collections.Generic;

namespace BLL.DTO
{
    public class ValidationResultDTO
    {
        public int Id { get; set; }
        public int AffectedLines { get; set; }
        public List<string> Notifications { get; set; }
        public bool Success => (Id > 0 || AffectedLines > 0) && Notifications.Count == 0;
    }
}
