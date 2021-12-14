using Microsoft.EntityFrameworkCore;
using Moq;

using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using BLL.Services.IMPL;
using BLL.Services.Interfaces;
using CCL.Security;
using DAL.EF;
using DAL.Entities;
using DAL.Repository.Interfaces;
using User = CCL.Security.User;

namespace BLL.Tests
{
    public class TaskServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new TaskService(nullUnitOfWork));
        }

        [Fact]
        public void GetTasks_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Progger(3, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ITaskService taskService = new TaskService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => taskService.GetTasks(0));
        }

        [Fact]
        public void GetTasks_FromDAL_CorrectMappingToTaskDTO()
        {
            // Arrange
            User user = new CTO(1, "test", 1);
            SecurityContext.SetUser(user);
            var taskService = GetTaskService();
            

            // Act
            var actualTaskDto = taskService.GetTasks(0).First();
            

            // Assert
            Assert.True(
                actualTaskDto.TaskID == 1
                && actualTaskDto.Name == "testN"
                && actualTaskDto.Description == "testD"
                );
        }

        ITaskService GetTaskService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedTask = new Task() { TaskID = 1, Name = "testN", Estimate = 5, Importance = 4,Description = "testD"};
            var mockDbSet = new Mock<ITaskRepository>();
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<Task,bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<Task>() { expectedTask }
                    );
            mockContext
                .Setup(context =>
                    context.Tasks)
                .Returns(mockDbSet.Object);

            ITaskService streetService = new TaskService(mockContext.Object);

            return streetService;
        }
    }
}