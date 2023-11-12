using Microsoft.AspNetCore.Mvc;
using ReficioSolution.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ReficioSolution.Controllers;

[Authorize]
public class FilledOutServiceFormController : Controller
{
    private readonly ServiceFormRepository _repository;

    public FilledOutServiceFormController(ServiceFormRepository repository)
    {
        _repository = repository;
    }
    
    public IActionResult Index()
    {
        var serviceFormEntry = _repository.GetAll();
        return View(serviceFormEntry);
    }
}