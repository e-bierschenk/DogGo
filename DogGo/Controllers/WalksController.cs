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
                Walkers = _walkerRepository.GetAllWalkers(),
                ChosenDogIds = new List<int>()
            };
            return View(vm);
        }

        // POST: WalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WalkFormViewModel vm)
        {
            try
            {
                foreach (int dogId in vm.ChosenDogIds)
                {
                    vm.Walk.DogId = dogId;
                    _walkRepository.AddWalk(vm.Walk);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(vm);
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

        // GET: WalksController/Delete
        public ActionResult Delete()
        {
            WalkDeleteViewModel vm = new WalkDeleteViewModel
            {
                Walks = _walkRepository.GetAll()
            };

            vm.ChosenWalkIds = new bool[vm.Walks.Count];
            return View(vm);
        }


        // POST: WalksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(WalkDeleteViewModel vm)
        {
            try
            {
                for (int i = 0; i < vm.ChosenWalkIds.Length; i++)
                {
                    if (vm.ChosenWalkIds[i] == true)
                    {
                        _walkRepository.DeleteWalk(i + 1);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
