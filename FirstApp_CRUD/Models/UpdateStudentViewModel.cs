namespace FirstApp_CRUD.Models
{
    public class UpdateStudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Faculty { get; set; }
    }
}
