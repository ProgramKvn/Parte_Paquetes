using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers;
using System.Security.Claims;
using System.Security.Principal;
using Infraestructure.Data;
using ApplicationCore.Entities;
using AspNetCoreHero.ToastNotification.Abstractions;
using ApplicationCore.Interfaces;

namespace WebApp.Areas.Perfil.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly MyRepository<User> _repositoryUser;
        private readonly IAppLogger<UserProfileModel> _logger;

        private INotyfService _notyfService { get; }
        public User user { get; set; }

        public UserProfileModel(MyRepository<User> repositoryUser, INotyfService notyfService, IAppLogger<UserProfileModel> logger)
        {
            _repositoryUser = repositoryUser;
            _notyfService = notyfService;
            _logger = logger;

        }
       /* public async Task<IActionResult> OnGetAsync()
        {
            var usuarios = await _repositoryUser.GetByIdAsync((((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value));

            if(usuarios == null)
            {
                _notyfService.Error("Usuario no encontrado");
                return Page();
            }
            user = usuarios;
            return Page();
        } */
    }
}
