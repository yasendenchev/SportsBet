using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SportsBet.Data.Model;
using SportsBet.Data.Repositories;
using SportsBet.Data.UnitOfWork;
using SportsBet.Services;

namespace SportsBet.Service.Tests
{
    [TestFixture]
    class Update_Should
    {
        Mock<IEfRepository<Event>> repositoryMock;
        Mock<IUnitOfWork> unitOfWorkMock;
        Mock<IDateTimeProvider> dateTimeProviderMock;

        int sampleId;
        string sampleName;
        int sampleOddFirst;
        int sampleOddDraw;
        int sampleOddSecond;
        DateTime sampleStartDate;
        DateTime fakeNow;
        Guid guid;
        EventService service;
        Event ev;

        [SetUp]
        public void SetUp()
        {
            repositoryMock = new Mock<IEfRepository<Event>>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            dateTimeProviderMock = new Mock<IDateTimeProvider>();

            sampleId = 1;
            sampleName = "Sample";
            sampleOddFirst = 1;
            sampleOddDraw = 1;
            sampleOddSecond = 2;
            sampleStartDate = new DateTime(2015, 10, 10, 22, 0, 0);
            fakeNow = new DateTime(2016, 2, 1, 10, 0, 0);
            guid = new Guid();

            ev = new Event(sampleId, sampleName, sampleOddFirst, sampleOddDraw, sampleOddSecond, sampleStartDate);
            service = new EventService(repositoryMock.Object, unitOfWorkMock.Object, dateTimeProviderMock.Object);

            dateTimeProviderMock.Setup(d => d.Now()).Returns(fakeNow);
            repositoryMock.Setup(r => r.GetById(guid)).Returns(ev);

            service.Update(guid, sampleName + "Changed", sampleOddFirst, sampleOddDraw, sampleOddSecond, sampleStartDate.ToString());
        }

        [Test]
        public void CallEventRepositoryGetById_WhenInvoked()
        {
            repositoryMock.Verify(x => x.GetById(guid), Times.Once);
        }

        [Test]
        public void CallEventRepositoryUpdate_WhenInvoked()
        {
            repositoryMock.Verify(x => x.Update(ev), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkCommit()
        {
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void ChangeName_WhenPassingDifferentNameAsArgument()
        {
            var changedName = sampleName + "Changed";
            Assert.AreEqual(changedName, ev.Name);
        }
    }
}
