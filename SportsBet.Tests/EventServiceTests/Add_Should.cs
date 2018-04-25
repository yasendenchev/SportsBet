using Moq;
using SportsBet.Data.Model;
using SportsBet.Data.Repositories;
using SportsBet.Data.UnitOfWork;
using SportsBet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SportsBet.Service.Tests
{
    [TestFixture]
    public class Add_Should
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
            DateTime fakeNow = new DateTime(2016, 2, 1);
            guid = new Guid();
            service = new EventService(repositoryMock.Object, unitOfWorkMock.Object, dateTimeProviderMock.Object);
            ev = new Event(sampleId, sampleName, sampleOddFirst, sampleOddDraw, sampleOddSecond, sampleStartDate);
            service.DeleteById(guid);
            repositoryMock.Setup(r => r.GetById(guid)).Returns(ev);
            dateTimeProviderMock.Setup(d => d.Now()).Returns(fakeNow);
            service.Add(sampleName, sampleOddFirst, sampleOddDraw, sampleOddSecond, sampleStartDate.ToString());
        }

        [Test]
        public void CallRepositoryAddWithSameProperties_WhenInvoked()
        {
            repositoryMock.Verify(r => r.Add(It.Is<Event>(arg => arg.Name == sampleName)));
        }

        [Test]
        public void CallUnitOfWorkCommit_WhenInvoked()
        {
            unitOfWorkMock.Verify(u => u.Commit(), Times.Once);
        }
    }
}
