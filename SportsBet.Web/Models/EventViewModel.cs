using AutoMapper;
using SportsBet.Data.Model;
using SportsBet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsBet.Models
{
    public class EventViewModel : IMapFrom<Event>, ICustomMappings
    {
        public int EventID { get; set; }

        public string Name { get; set; }

        public double OddsForFirstTeam { get; set; }

        public double OddsForDraw { get; set; }

        public double OddsForSecondTeam { get; set; }

        public DateTime StartDate { get; set; }

        public bool StartHasPassed { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(eventViewModel => eventViewModel.EventID, cfg => cfg.MapFrom(ev => ev.EventID))
                .ForMember(eventViewModel => eventViewModel.Name, cfg => cfg.MapFrom(ev => ev.Name))
                .ForMember(eventViewModel => eventViewModel.OddsForFirstTeam, cfg => cfg.MapFrom(ev => ev.OddsForFirstTeam))
                .ForMember(eventViewModel => eventViewModel.OddsForDraw, cfg => cfg.MapFrom(ev => ev.OddsForDraw))
                .ForMember(eventViewModel => eventViewModel.OddsForSecondTeam, cfg => cfg.MapFrom(ev => ev.OddsForSecondTeam))
                .ForMember(eventViewModel => eventViewModel.StartDate, cfg => cfg.MapFrom(ev => ev.StartDate))
                .ForMember(eventViewModel => eventViewModel.StartHasPassed, cfg => cfg.MapFrom(ev => DateTime.Compare(DateTime.Now, ev.StartDate) > 0));
        }
    }
}