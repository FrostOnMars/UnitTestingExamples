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
    internal class HousekeeperServiceTests
    {
        private HousekeeperService _service;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _housekeeper;
        private string _statementFileName;

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper() { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _housekeeper,

            }.AsQueryable());

            _statementFileName = "fileName";
            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator
                .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, (_statementDate)))
                .Returns(() => _statementFileName);

            _emailSender = new Mock<IEmailSender>();
            var messageBox = new Mock<IXtraMessageBox>();

            _messageBox = messageBox;
            _service = new HousekeeperService(unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GeneratesStatements()
        {
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
                sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, (_statementDate)));
        }

        //TODO: replace the following three tests with one parameterized test

        [Test]
        public void SendStatementEmails_HousekeepersEmailIsNull_ShouldNotGenerateStatements()
        {
            _housekeeper.Email = null;

            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
                sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, (_statementDate)), Times.Never);
        }

        [Test]
        public void SendStatementEmails_HousekeepersEmailIsWhitespace_ShouldNotGenerateStatements()
        {
            _housekeeper.Email = " ";

            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
                sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, (_statementDate)), Times.Never);
        }

        [Test]
        public void SendStatementEmails_HousekeepersEmailIsEmpty_ShouldNotGenerateStatements()
        {
            _housekeeper.Email = "";

            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
                sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, (_statementDate)), Times.Never);
        }
        //end TODO

        [Test]
        public void SendStatementEmails_WhenCalled_ShouldEmailStatement()
        {
            _service.SendStatementEmails(_statementDate);

            VerifyEmailIsSent();
        }


        [Test]
        public void SendStatementEmails_StatementFileNameIsNull_ShouldNotEmailStatement()
        {
            _statementFileName = null;

            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_StatementFileNameIsEmptyString_ShouldNotEmailStatement()
        {
            _statementFileName = String.Empty;

            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_StatementFileNameIsWhiteSpace_ShouldNotEmailStatement()
        {
            _statementFileName = " ";

            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }
        private void VerifyEmailIsSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                _housekeeper.Email,
                _housekeeper.StatementEmailBody,
                _statementFileName,
                It.IsAny<string>()));
        }
        private void VerifyEmailNotSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Never);
        }
    }
}
