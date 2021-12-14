using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace DAL.Entities
{
    public class Catalog
    {
        public int CatalogID { get; set; }
        public string Name { get; set; }
        public DateTime DDM { get; set; }
        public List<Task> Tasks { get; set; }
        //public IEnumerable<User> Users { get; set; }

        private static Catalog instance;
        public Catalog()
        {
        }
        //Singleton
        public static Catalog GetInstance()
        {
            if (instance == null)
            {
                instance = new Catalog();
            }

            return instance;
        }
    }
}