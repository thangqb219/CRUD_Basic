using System.ComponentModel.DataAnnotations;

namespace FirstApp_CRUD.Models.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public DateTime Birthday { get; set;}
        public string Address { get; set; }
        public string Faculty { get; set;}
    }
}
