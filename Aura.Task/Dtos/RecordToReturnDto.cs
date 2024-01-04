using System.ComponentModel.DataAnnotations;

namespace Aura.PracticalTask.Dtos
{
    public class RecordToReturnDto
    {
        public RecordToReturnDto(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
       
        public string Name { get; set; }

    }
}
