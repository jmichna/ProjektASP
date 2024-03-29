﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektASP.Models;

namespace ProjektASP.Controllers
{
    [Authorize(Roles = "admin")]
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var libraries = _libraryService.GetAllLibraries();
            return View(libraries);
        }

        public IActionResult Details(int id)
        {
            var library = _libraryService.GetLibraryById(id);

            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        public IActionResult Create()
        {
            return View(new Library());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Library library)
        {
            if (ModelState.IsValid)
            {
                _libraryService.AddLibrary(library);;
                return RedirectToAction("Index");
            }

            return View(library);
        }

        public IActionResult Edit(int id)
        {
            var library = _libraryService.GetLibraryById(id);

            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Library library)
        {
            if (id != library.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _libraryService.UpdateLibrary(library);
                }
                catch (Exception)
                {
                    // Handle exception, e.g., concurrency conflict
                    throw;
                }

                return RedirectToAction("Index");
            }

            return View(library);
        }

        public IActionResult Delete(int id)
        {
            var library = _libraryService.GetLibraryById(id);

            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var library = _libraryService.GetLibraryById(id);

            if (library != null)
            {
                _libraryService.DeleteLibrary(id);
            }

            return RedirectToAction("Index");
        }
    }
}
