using Microsoft.AspNetCore.Mvc;
using ReficioSolution.Models.Serviceform;
using ReficioSolution.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace ReficioSolution.Controllers
{
    [Authorize]
    public class ServiceOrderController : Controller
    {
        private readonly ServiceFormRepository _repository;

        public ServiceOrderController(ServiceFormRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var serviceFormEntry = _repository.GetSomeOrderInfo();
            return View(serviceFormEntry);
        }
    }
}