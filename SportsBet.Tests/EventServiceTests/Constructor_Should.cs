using Moq;
using NUnit.Framework;
using SportsBet.Data.Model;
using SportsBet.Data.Repositories;
using SportsBet.Data.UnitOfWork;
using SportsBet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBet.Service.Tests
{
    [TestFixture]
    class Constructor_Should
    {
        Mock<IEfRepository<Event>> repositoryMock = new Mock<IEfRepository<Event>>();
        Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        Mock<IDateTimeProvider> dateTimeProviderMock = new Mock<IDateTimeProvider>();

        [Test]
        public void ThrowArgumentNullException_WhenEventRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EventService(null, unitOfWorkMock.Object, dateTimeProviderMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EventService(repositoryMock.Object, null, dateTimeProviderMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenDateTimeProviderIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EventService(repositoryMock.Object, unitOfWorkMock.Object, null));
        }

        [Test]
        public void NotThrow_WhenPassedDependenciesAreNotNull()
        {
            Assert.DoesNotThrow(() => new EventService(repositoryMock.Object, unitOfWorkMock.Object, dateTimeProviderMock.Object));
        }
    }
}
