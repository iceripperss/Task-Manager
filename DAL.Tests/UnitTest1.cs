using System;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DAL.Entities;
using DAL.Repository.IMPL;
using Moq;

namespace DAL.Tests
{
    class TestTaskRepository
        : BaseRepository<Task>
    {
        public TestTaskRepository(DbContext context)
            : base(context)
        {
        }
        
    }

    public class BaseRepositoryForTest
    {
        [Fact]
        public void Create_InputStreetInstance_CalledAddMethodOFDBSetWithStreetInstance()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<CatalogContext>().Options;
            var mockContext = new Mock<CatalogContext>(opt);
            var mockDbSet = new Mock<DbSet<Task>>();
            mockContext.Setup(context => context.Set<Task>()).Returns(mockDbSet.Object);
            var repository = new TestTaskRepository(mockContext.Object);
            Task expectedStreet = new Mock<Task>().Object;

            repository.Create(expectedStreet);
            
            mockDbSet.Verify(dbSet => dbSet.Add(expectedStreet), Times.Once());
            
        }
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<CatalogContext>().Options;
            var mockContext = new Mock<CatalogContext>(opt);
            var mockDbSet = new Mock<DbSet<Task>>();
            mockContext.Setup(context => context.Set<Task>()).Returns(mockDbSet.Object);
            var repository = new TestTaskRepository(mockContext.Object);
            Task expectedStreet = new Task() { TaskID = 1};
            
            mockDbSet.Setup(mock => mock.Find(expectedStreet.TaskID)).Returns(expectedStreet);
            
            repository.Delete(expectedStreet.TaskID);
            
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStreet.TaskID), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedStreet), Times.Once());
        }
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<CatalogContext>()
                .Options;
            var mockContext = new Mock<CatalogContext>(opt);
            var mockDbSet = new Mock<DbSet<Task>>();
            mockContext.Setup(context => context.Set<Task>()).Returns(mockDbSet.Object);

            Task expectedStreet = new Task() { TaskID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.TaskID)).Returns(expectedStreet);
            var repository = new TestTaskRepository(mockContext.Object);
            
            var actualStreet = repository.Get(expectedStreet.TaskID);
            
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStreet.TaskID), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }
    }
}