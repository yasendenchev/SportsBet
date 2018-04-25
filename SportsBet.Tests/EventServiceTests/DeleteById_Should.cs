using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SportsBet.Data.Repositories;
using SportsBet.Data.Model;
using SportsBet.Data.UnitOfWork;
using SportsBet.Services;

namespace SportsBet.Service.Tests
{
    [TestFixture]
    class DeleteById_Should
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

            repositoryMock.Setup(r => r.GetById(guid)).Returns(ev);
            dateTimeProviderMock.Setup(d => d.Now()).Returns(fakeNow);
            
            service.DeleteById(guid);
        }



        [Test]
        public void CallRepositoryGetById_WhenInvoked()
        {
            repositoryMock.Verify(x => x.GetById(guid), Times.Once());
        }

        [Test]
        public void CallDateTimeProviderNow_WhenInvoked()
        {
            dateTimeProviderMock.Verify(x => x.Now(), Times.Once());
        }

        [Test]
        public void ShouldSetEventIsDeletedToTrue_WhenEventExists()
        {
            Assert.AreEqual(ev.IsDeleted, true);
        }

        [Test]
        public void ShouldSetEventDeletedOnToCurrentDate_WhenEventExists()
        {
            Assert.AreEqual(ev.DeletedOn, fakeNow);
        }

        [Test]
        public void ShouldCallRepositoryUpdate_WhenInvoked()
        {
            repositoryMock.Verify(x => x.Update(ev), Times.Once());
        }

        [Test]
        public void ShouldCallUnitOfWorkCommit_WhenInvoked()
        {
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }
    }
}
