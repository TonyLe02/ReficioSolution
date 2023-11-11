﻿using Microsoft.AspNetCore.Mvc;
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



        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(); // User not found
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                // Optionally, you can perform additional actions after a successful delete
                // For example, refreshing the user list or displaying a success message.
                TempData["SuccessMessage"] = "User deleted successfully.";
            }
            else
            {
                // Handle errors, such as displaying an error message
                TempData["ErrorMessage"] = "Error deleting user.";
            }

            return RedirectToAction("Index");
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
