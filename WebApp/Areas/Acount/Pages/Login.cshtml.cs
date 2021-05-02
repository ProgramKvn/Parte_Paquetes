using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Entities.NoMapped;
using ApplicationCore.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers;

namespace WebApp.Areas.Acount.Pages.Login
{
    public class LoginModel : PageModel
    {
        private MyRepository<LoginUser> _loginUser;
        private readonly MyRepository<User> _User;
        private INotyfService _notyfService { get; }
        private readonly IAppLogger<LoginModel> _logger;

        public LoginModel(MyRepository<LoginUser> loginUser, 
            INotyfService notyfService,
            IAppLogger<LoginModel> logger,
            MyRepository<User> repositoryUser)
        {
            _loginUser = loginUser;
            _notyfService = notyfService;
            _User = repositoryUser;
            _logger = logger;
        }

        [BindProperty]
        public LoginUser LoginUser { get; set; }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                  var User = await _User.ListAsync();

                    Console.WriteLine();
                    
                    var result = User.Where(x => x.Email == LoginUser.email).SingleOrDefault();

                    if(result != null && HashHelper.CheckHash(LoginUser.password, result.Contraseña, result.salt))
                    {
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.ID.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, result.NombreCompleto()));
                        identity.AddClaim(new Claim(ClaimTypes.Email, result.Email));
                        identity.AddClaim(new Claim(ClaimTypes.Webpage, result.Fotografia));
                        identity.AddClaim(new Claim(ClaimTypes.Role, result.Rol));
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                            new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(1), IsPersistent = true }
                            );
                            
                        _notyfService.Success("Bienvenido, " + result.NombreCompleto());
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                       _notyfService.Warning("El usuario o la contraseña son incorrectos");
                        ModelState.AddModelError(nameof(LoginUser.email), "El correo electronico y/o la contraseña son incorrectos");
                        return Page();                   
                    }
                }
                else
                {
                    _notyfService.Warning("Por favor complete todos los campos");
                    return Page();
                }
            }
            catch(Exception ex) {
                _notyfService.Error("Ocurrio un error en el servidor: ");
                _logger.LogWarning(ex.Message);
                return Page();
            }
        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Acount/Login");
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
