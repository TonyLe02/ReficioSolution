using Microsoft.AspNetCore.Mvc;
using ReficioSolution.Models.Serviceform;
using ReficioSolution.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ReficioSolution.Controllers
{
    [Authorize]
    public class ServiceFormController : Controller
    {
        private readonly ServiceFormRepository _repository;

        public ServiceFormController(ServiceFormRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ServiceFormViewModel serviceFormViewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(serviceFormViewModel);
                return RedirectToAction("Index", "ServiceOrder");
            }
            
            return View(serviceFormViewModel);
        }
    }
}