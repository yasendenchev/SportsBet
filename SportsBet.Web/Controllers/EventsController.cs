using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SportsBet.Data;
using SportsBet.Models;
using SportsBet.Services.Contracts;

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

            var models = events.ProjectTo<EventViewModel>().ToList();

            return View(models);
        }


        //GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventID,Name,OddsForFirstTeam,OddsForDraw,OddsForSecondTeam,StartDate,StartHasPassed,IsInEditMode")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                this.eventService.Add(eventViewModel.Name, eventViewModel.OddsForFirstTeam, eventViewModel.OddsForDraw, eventViewModel.OddsForSecondTeam, eventViewModel.StartDate.ToString());
                return RedirectToAction("Preview");
            }

            return View(eventViewModel);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ev = this.eventService.GetById((Guid)id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            var eventViewModel = this.mapper.Map<EventViewModel>(ev);
            return View(eventViewModel);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventID,Name,OddsForFirstTeam,OddsForDraw,OddsForSecondTeam,StartDate,StartHasPassed,IsInEditMode")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                this.eventService.Update(eventViewModel.Id, eventViewModel.Name, eventViewModel.OddsForFirstTeam, eventViewModel.OddsForDraw, eventViewModel.OddsForSecondTeam, eventViewModel.StartDate.ToString());
                return RedirectToAction("Preview");
            }
            return View(eventViewModel);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ev = this.eventService.GetById((Guid)id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            var eventViewModel = this.mapper.Map<EventViewModel>(ev);
            return View(eventViewModel);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.eventService.DeleteById(id);

            return RedirectToAction("Preview");
        }

    }
}
