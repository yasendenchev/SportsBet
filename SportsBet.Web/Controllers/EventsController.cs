using AutoMapper;
using AutoMapper.QueryableExtensions;
using SportsBet.Data.Model;
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
        public ActionResult Preview()
        {

            var events = this.eventService.GetAll();

            var model = events.ProjectTo<EventViewModel>().ToList();

            return this.View(model);
        }


        public ActionResult EditView()
        {

            var events = this.eventService.GetAll();

            var model = (IEnumerable<EventViewModel>)events.ProjectTo<EventViewModel>();

            if (Session["Events"] != null)
            {

                return View((IEnumerable<EventViewModel>)Session["Events"]);
            }


            Session["Events"] = model;
            return View(model);

            //return this.View(model);
        }

        [HttpPost]
        public JsonResult Edit(Guid id, string name, double oddsForFirstTeam, double oddsForDraw, double oddsForSecondTeam, string startDate)
        {
            Event ev = this.eventService.GetById(id);
            var model = mapper.Map<EventViewModel>(ev);
            this.eventService.Update(id, name, oddsForFirstTeam, oddsForDraw, oddsForSecondTeam, startDate);
            return Json(new JsonResult { Data = model }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(Guid id)
        {
            this.eventService.DeleteById(id);
            IEnumerable<EventViewModel> ev = (IEnumerable<EventViewModel>)Session["Persons"];
            ev = ev.Where(p => p.Id != id).ToList();
            Session["Events"] = ev;
            bool result = true;
            return Json(new JsonResult { }, JsonRequestBehavior.AllowGet);
        }


    }
}