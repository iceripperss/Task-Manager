namespace BLL.DTO
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public int Importance { get; set; }
        public int Estimate { get; set; }
        public string Description { get; set; }
    }
}