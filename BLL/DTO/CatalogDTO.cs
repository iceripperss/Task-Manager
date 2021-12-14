using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.DTO
{
    public class CatalogDTO
    {
        public int CatalogID { get; set; }
        public string Name { get; set; }
        public DateTime DDM { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
        //public IEnumerable<User> Users { get; set; }
    }
}