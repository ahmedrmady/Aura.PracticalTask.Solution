using System.ComponentModel.DataAnnotations;

namespace Aura.PracticalTask.Dtos
{
    public class RecordDto
    {
        [Required]
        public string Name { get; set; }
    }
}
