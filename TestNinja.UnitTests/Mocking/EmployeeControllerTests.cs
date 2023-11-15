using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class EmployeeControllerTests
    {

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployee()
        {
            var Storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(Storage.Object);

            controller.DeleteEmployee(1);

            Storage.Verify(s => s.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnsRedirectToAction()
        {
            var Storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(Storage.Object);

            controller.DeleteEmployee(1);

            Assert.That(controller.DeleteEmployee(1), Is.TypeOf<RedirectResult>());
        }
    }
}
