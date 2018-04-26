using AutoMapper;
using AutoMapper.QueryableExtensions;
using SportsBet.Models;
using SportsBet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsBet.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;
        public EventsController(IEventService eventService, IMapper mapper)
        {
            if (eventService == null)
            {
                throw new ArgumentNullException();
            }
            if (mapper == null)
            {
                throw new ArgumentNullException();
            }
            this.eventService = eventService;
            this.mapper = mapper;
        }
        // GET: Events
        public ActionResult View()
        {

            var events = this.eventService.GetAll();

            var model = events.ProjectTo<EventViewModel>().ToList();


            return this.View(model);
        }

        
    }
}