using Microsoft.AspNetCore.Mvc;
using ReficioSolution.Models;
using ReficioSolution.Repositories;

namespace ReficioSolution.Controllers
{
    public class SjekklisterController : Controller
    {
        private readonly CheckListRepository _repository;

        public SjekklisterController(CheckListRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var Checklist = _repository.GetSomeOrderInfo();
            return View(Checklist);
        }
    }
}