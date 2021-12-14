namespace DAL.Entities
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public int Importance { get; set; }
        public int Estimate { get; set; }
        public string Description { get; set; }
        public int CatalogID { get; set; }
        
        //prototype
        public Task Clone()
        {
            var task = new Task
            {
                TaskID = TaskID,
                CatalogID = CatalogID,
                Name = Name.Clone() as string,
                Importance = Importance,
                Estimate = Estimate,
                Description = Description.Clone() as string
            };
            return task;
        }
    }
}