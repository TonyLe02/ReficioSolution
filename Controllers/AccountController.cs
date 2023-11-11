using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReficioSolution.Areas.Identity.Data;
using ReficioSolution.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ReficioSolution.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ReficioSolutionUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ReficioSolutionUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            // Get a list of users and roles
            var users = await _userManager.Users.ToListAsync();
            var roles = await _roleManager.Roles.ToListAsync();

            // Pass the users and roles to the view
            var viewModel = new AccountViewModel { Users = users, Roles = roles };
            return View(viewModel);
        }

        // Additional actions can be added as needed (e.g., Create, Edit)
    }

}
