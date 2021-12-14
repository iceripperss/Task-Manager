using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using DAL.EF;
using DAL.Entities;

namespace BLL.Services.IMPL
{
    public class TaskService
        : ITaskService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public TaskService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<TaskDTO> GetTasks(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(CTO))
            {
                throw new MethodAccessException();
            }

            var catalogId = user.CatalogID;
            var tasksEntities = 
                _database
                    .Tasks
                    .Find(z => z.CatalogID == catalogId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Task, TaskDTO>()
                    ).CreateMapper();
            var tasksDto =
                mapper
                    .Map<IEnumerable<Task>, List<TaskDTO>>(
                        tasksEntities);
            return tasksDto;
        }
        
        public void AddTask(TaskDTO task)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(CTO))
            {
                throw new MethodAccessException();
            }
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            validate(task);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>()).CreateMapper();
            var taskEntity = mapper.Map<TaskDTO, Task>(task);
            _database.Tasks.Create(taskEntity);
        }

        private void validate(TaskDTO task)
        {
            if (string.IsNullOrEmpty(task.Name))
            {
                throw new ArgumentException("Name повинне містити значення!");
            }
        }
        
    }
}