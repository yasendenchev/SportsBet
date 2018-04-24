using SportsBet.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBet.Services.Contracts
{
    public interface IEventService : IService
    {
        void Add(string eventName, double oddsForFirstTeam, double oddsForDraw, double oddsForSecondTeam, string startDate);

        IQueryable<Event> GetAll();

        Event GetById(Guid Id);

        void Update(Guid Id, string eventName, double oddsForFirstTeam, double oddsForDraw, double oddsForSecondTeam, string startDate);

        void DeleteById(Guid Id);
    }
}
