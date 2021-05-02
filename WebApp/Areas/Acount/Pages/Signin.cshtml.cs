using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers;

namespace WebApp.Areas.Acount.Pages.Signin
{
    public class SigninModel : PageModel
    {
        private readonly MyRepository<DepSV> _repositoryDepSV;
        private readonly MyRepository<MunSV> _repositoryMunSV;
        private readonly MyRepository<User> _repositoryUser;
        private readonly MyRepository<UserAddress> _repositoryUserAddress;
        private readonly IAppLogger<SigninModel> _logger;

        private INotyfService _notyfService { get; }

        public SigninModel(MyRepository<DepSV> repositoyDepSV, 
            MyRepository<MunSV> repositoryMunSV, 
            MyRepository<User> repositoryUser,
            MyRepository<UserAddress> repositoryUserAddress, 
            INotyfService notyfService,
            IAppLogger<SigninModel> logger
)
        {
            _repositoryDepSV = repositoyDepSV;
            _repositoryMunSV = repositoryMunSV;
            _repositoryUser = repositoryUser;
            _notyfService = notyfService;
            _repositoryUserAddress = repositoryUserAddress;
            _logger = logger;
        }

        [BindProperty]
        public IEnumerable<DepSV> Departamento { get; set; }
        [BindProperty]
        public IEnumerable<MunSV> Municipio { get; set;}
        [BindProperty]
        public User user { get; set; }
        [BindProperty]
        public UserAddress userAddress { get; set; }

        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                RedirectToPage("Index");
            }
            else
            {
                RedirectToPage("/Acount/Signin");
            }

            Departamento = await _repositoryDepSV.ListAsync();

        }

        public async Task<JsonResult> OnGetMun(string DepName) 
        {
            try     
            {
                Departamento = await _repositoryDepSV.ListAsync();
                Departamento = Departamento.Where(x => x.DepName == DepName);

                Municipio = await _repositoryMunSV.ListAsync();
                Municipio = Municipio.Where(x => x.DEPSV_ID == Departamento.First().ID);
                if (Municipio == null)
                {
                    return new JsonResult( new { selected = true});
                }
                return new JsonResult(new { Municipio });
            }
            catch ( Exception ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _repositoryUser.ListAsync();
                    //Se hace una consulta para comparar el EMAIL y evitar que se repita
                    var result = usuario.Where(x => x.Email == user.Email).SingleOrDefault();
                    //Se hace una consulta para comparar el DUI y evitar que se repita
                    var resultdui = usuario.Where(x => x.DUI == user.DUI).SingleOrDefault();

                    ///Si el email esta registrado traera ese registro, por tanto dara error
                    if (result != null)
                    {
                        _notyfService.Warning("El correo electronico ya esta en uso");
                        OnGetAsync().GetAwaiter();
                        return Page();
                    }
                    ///Si el DUI esta registrado traera ese registro, por tanto dara error
                    else if (resultdui != null)
                    {
                        _notyfService.Warning("El DUI introducido ya esta registrado");
                        OnGetAsync().GetAwaiter();
                        return Page();
                    }
                    //Si ambos son null, entonces el usuario se registrara correctamente
                    else
                    {
                        _logger.LogInformation("¡Un nuevo usuario ha sido correctamente registrado!");
                        //Se encrypta la contraseña
                        var hash = HashHelper.Hash(user.Contraseña);
                        user.Contraseña = hash.Password;
                        user.salt = hash.Salt;

                    //Se guarda el registro de usuario
                        await _repositoryUser.AddAsync(user);

                        //Se asgina el ID usuario a la tabla address
                        userAddress.IDUsuario = user.ID;
                        
                        //Se guarda la direccion
                        await _repositoryUserAddress.AddAsync(userAddress);
                        _notyfService.Success("¡Se ha registrado correctamente!");
                        return RedirectToPage("/Login");
                    }
                }
                else
                {
                    _notyfService.Warning("Su formulario no cumple las reglas de negocio");
                     OnGetAsync().GetAwaiter();
                    return Page();
                }
            }
            catch (Exception ex)
            {
                _notyfService.Error("Ocurrio un error en el servidor, intente nuevamente");
                _logger.LogWarning(ex.Message);
                OnGetAsync().GetAwaiter();
                return Page();
                    }
        }
    }
}
