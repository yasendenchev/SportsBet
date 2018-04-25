using SportsBet.Data.Model;
using SportsBet.Data.Repositories;
using SportsBet.Data.UnitOfWork;
using SportsBet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBet.Services
{
    public class EventService : IEventService
    {
        private const string argNullMessage = "cannot be null.";
        private readonly IEfRepository<Event> eventRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDateTimeProvider dateTimeProvider;
        private int rowsCount;

        public EventService(IEfRepository<Event> eventRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            if (eventRepository == null)
            {
                throw new ArgumentNullException(String.Format("EventRepository" + argNullMessage));
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException(String.Format("UnitOfWork" + argNullMessage));
            }

            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException(String.Format("DateTimeProvider" + argNullMessage));
            }

            this.eventRepository = eventRepository;
            this.unitOfWork = unitOfWork;
            this.dateTimeProvider = dateTimeProvider;
            this.rowsCount = GetRowsCount();
        }

        public void Add(string name, double oddsForFirstTeam, double oddsForDraw, double oddsForSecondTeam, string startDate)
        {
            var date = DateTime.Parse(startDate);
            var ev = new Event(++this.rowsCount, name, oddsForFirstTeam, oddsForDraw, oddsForSecondTeam, date);

            this.eventRepository.Add(ev);
            this.unitOfWork.Commit();
        }

        public void DeleteById(Guid id)
        {
            var ev = this.eventRepository.GetById(id);
            var dateDeleted = this.dateTimeProvider.Now();

            if (ev != null)
            {
                ev.IsDeleted = true;
                ev.DeletedOn = dateDeleted;

                this.eventRepository.Update(ev);
                this.unitOfWork.Commit();
            }
        }

        public IQueryable<Event> GetAll()
        {
            return this.eventRepository.All;
        }

        public Event GetById(Guid id)
        {
            return this.eventRepository.GetById(id);
        }

        public void Update(Guid id, string eventName, double oddsForFirstTeam, double oddsForDraw, double oddsForSecondTeam, string startDate)
        {
            var ev = this.eventRepository.GetById(id);
            ev.Name = eventName;
            ev.OddsForFirstTeam = oddsForFirstTeam;
            ev.OddsForDraw = oddsForDraw;
            ev.OddsForSecondTeam = oddsForSecondTeam;
            ev.StartDate = DateTime.Parse(startDate);

            this.eventRepository.Update(ev);
            this.unitOfWork.Commit();
        }

        private int GetRowsCount()
        {
            return eventRepository.All.Count();
        }
    }
}
