using AutoMapper;
using SportsBet.Data.Model;
using SportsBet.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsBet.Models
{
    public class EventViewModel : IMapFrom<Event>, ICustomMappings
    {
        public Guid Id { get; set; }

        [Display(Name = "EventId")]
        public int EventID { get; set; }

        [Display(Name = "EventName")]
        public string Name { get; set; }

        [Display(Name = "OddsForFirstTeam")]
        public double OddsForFirstTeam { get; set; }

        [Display(Name = "OddsForDraw")]
        public double OddsForDraw { get; set; }

        [Display(Name = "OddsForSecondTeam")]
        public double OddsForSecondTeam { get; set; }

        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        public bool StartHasPassed { get; set; }

        [Display(Name = "EventId")]
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(eventViewModel => eventViewModel.Id, cfg => cfg.MapFrom(ev => ev.Id))
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