using Microsoft.AspNetCore.Identity;
using ReficioSolution.Areas.Identity.Data;
using System.Collections.Generic;

namespace ReficioSolution.Models
{
    public class AccountManagerViewModel
    {
        public List<ReficioSolutionUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
    