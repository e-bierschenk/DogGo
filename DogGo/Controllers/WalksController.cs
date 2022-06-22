using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;

namespace DogGo.Controllers
{
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IWalkerRepository _walkerRepository;
        private readonly IDogRepository _dogRepository;

        public WalksController(IWalkRepository walkRepository, IWalkerRepository walkerRepository, IDogRepository dogRepository)
        {
            _walkRepository = walkRepository;
            _walkerRepository = walkerRepository;
            _dogRepository = dogRepository;
        }


        // GET: WalksController
        public ActionResult Index()
        {
            List<Walk> walks = _walkRepository.GetAll();
            return View(walks);
        }

        // GET: WalksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WalksController/Create
        public ActionResult Create()
        {
            WalkFormViewModel vm = new WalkFormViewModel
            {
                Walk = new Walk(),
                Dogs = _dogRepository.GetAllDogs(),
                Walkers = _walkerRepository.GetAllWalkers()
            };
            return View(vm);
        }

        // POST: WalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Walk walk)
        {
            try
            {
                _walkRepository.AddWalk(walk);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(walk);
            }
        }

        // GET: WalksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
