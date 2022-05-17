using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Topelab.Core.Helpers.Extensions;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Business.Factories;
using Topelab.RegisterActivity.Business.Services;
using Topelab.RegisterActivity.Business.Services.Entities;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Business.Test.Services
{
    [TestFixture]
    public class DataServiceTests
    {
        private MockRepository mockRepository;
        private Mock<IWinlogService> mockWinlogService;
        private Stack<Winlog> mockWinlogStack;
        private static int id = 0;

        [SetUp]
        public void SetUp()
        {
            mockWinlogStack = new Stack<Winlog>();

            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockWinlogService = this.mockRepository.Create<IWinlogService>();
            this.mockWinlogService
                .Setup(m => m.Save(It.IsAny<Winlog>()))
                .Returns((Winlog w) =>
                {
                    w.LocalId = ++id;
                    mockWinlogStack.Push(w);
                    Debug.Print(w.ToJSon());
                    return id;
                });
        }

        private DataService CreateService()
        {
            return new DataService(
                this.mockWinlogService.Object);
        }

        [Test]
        public void CalculateData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            var process = Process.GetCurrentProcess();
            var lastTimeActive = DateTime.Now.AddMinutes(-10);
            var processFactory = new ProcessDTOFactory();

            ProcessDTO currentProcess = processFactory.Create(process, "DataServiceTest", 1000);
            ProcessDTO currentProcess2 = processFactory.Create(process, "DataServiceTest", 1000);
            ProcessDTO currentProcess3 = processFactory.Create(process, "DataServiceTest", 1000);
            ProcessDTO currentProcess4 = processFactory.Create(process, "DataServiceTest", 1000);
            ProcessDTO currentProcess5 = processFactory.Create(process, "DataServiceTest2", 1000);
            
            Action<ProcessDTO> afterSave = null;

            // Act
            service.CalculateData(currentProcess, afterSave);
            service.CalculateData(currentProcess2, afterSave);
            service.CalculateData(currentProcess3, afterSave);
            service.CalculateData(currentProcess4, afterSave);
            service.CalculateData(currentProcess5, afterSave);

            // Assert
            Assert.IsTrue(mockWinlogStack.Peek().TotalTime > 0);
            this.mockRepository.VerifyAll();
        }
    }
}
