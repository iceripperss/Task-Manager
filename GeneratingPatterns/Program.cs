using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using DAL.Entities;

namespace GeneratingPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog.GetInstance().CatalogID = 1;
            Catalog.GetInstance().Name = "Petr";
            Catalog.GetInstance().DDM = DateTime.Now;
            Catalog.GetInstance().Tasks = new List<Task>();
            Catalog.GetInstance().Tasks.Add(new Task());
            
            Console.WriteLine("Singleton");
            Console.WriteLine($"CatalogID: {Catalog.GetInstance().CatalogID} Name:{Catalog.GetInstance().Name} DDM: {Catalog.GetInstance().DDM}");

            var task = Catalog.GetInstance().Tasks.First();

            task.Description = "Desc";
            task.Name = "Some task";
            task.TaskID = 1;
            task.CatalogID = 1;
            
            Console.WriteLine("Prototype");
            
            Console.WriteLine($"Description: {task.Description} Name:{task.Name} TaskID: {task.TaskID}");
            var cloneTask = task.Clone();
            cloneTask.Description = "Clone desc";
            
            Console.WriteLine($"Description: {cloneTask.Description} Name:{cloneTask.Name} TaskID: {cloneTask.TaskID}");
        }
    }
}