using ReficioSolution.Models.CheckList;
using Microsoft.AspNetCore.Mvc;
using ReficioSolution.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace ReficioSolution.Controllers
{
    [Authorize]
    public class CheckListController : Controller
    {
        private readonly CheckListRepository _repository;

        public CheckListController (CheckListRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CheckListViewModel checkListViewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(checkListViewModel);
                return RedirectToAction("Index", "CheckList");
            }
            
            return View(checkListViewModel);
        }
        
    }
}