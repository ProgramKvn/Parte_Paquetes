using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;
using WebApp.Helpers;
using System.Security.Claims;
using System.Security.Principal;

namespace WebApp.Areas.Paquetes.Pages
{
    [Authorize(Roles = "Cliente")]
    public class CreateModel : PageModel
    {
        private readonly MyRepository<Paquete> _repository;
        private readonly MyRepository<UserAddress> _repositoryUserAddress;
        private readonly MyRepository<MunSV> _repositoryMunicipio;
        private readonly MyRepository<DepSV> _repositoryDepartamento;
        private INotyfService _INotyfService { get; }
        private readonly IFileUploadService _fileUploadService;
        private readonly IAppLogger<CreateModel> _logger;
        public CreateModel(MyRepository<Paquete> repository, INotyfService iNotyfService, IFileUploadService fileUploadService, MyRepository<MunSV> repositoryMunicipio, MyRepository<DepSV> repositoryDepartamento, MyRepository<UserAddress> repositoryUserAddress)
        {
            _repository = repository;
            _INotyfService = iNotyfService;
            _fileUploadService = fileUploadService;
            _repositoryMunicipio = repositoryMunicipio;
            _repositoryDepartamento = repositoryDepartamento;
            _repositoryUserAddress = repositoryUserAddress;
        }
        [BindProperty]
        public Paquete Paquete { get; set; }
        public UserAddress userAddress { get; set; }
        [BindProperty]
        public IEnumerable<DepSV> depSVs { get; set; }
        [BindProperty]
        public IEnumerable<MunSV> munSVs { get; set; }
        public async Task OnGetAsync()
        {
            depSVs = await _repositoryDepartamento.ListAsync();

        }
        public async Task<JsonResult> OnGetMun(string DepName)
        {
            try
            {
                depSVs = await _repositoryDepartamento.ListAsync();
                depSVs = depSVs.Where(x => x.DepName == DepName);

                munSVs = await _repositoryMunicipio.ListAsync();
                munSVs = munSVs.Where(x => x.DEPSV_ID == depSVs.First().ID);
                if (munSVs == null)
                {
                    return new JsonResult(new { selected = true });
                }
                return new JsonResult(new { munSVs });
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
        }
        public async Task<IActionResult> OnPost(IFormFile Subir_Archivo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var idUserCookie = (((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value);
                    int idUsuario = Convert.ToInt32(idUserCookie);
                    var auxiliar = await _repositoryUserAddress.ListAsync();
                    var direccion = auxiliar.Where(x => x.IDUsuario == idUsuario).SingleOrDefault();

                    Paquete.String_Fotografia = await _fileUploadService.LocalStorage(Subir_Archivo, Paquete.Nombre_Fotografia(), "paquetes");
                    Paquete.Origen = direccion.Origen();
                    Paquete.Destino = Paquete.Destino_Func();
                    Paquete.UserId = idUsuario;
                    await _repository.AddAsync(Paquete);
                    _INotyfService.Success("Solicitud enviada de manera exitosa");
                    return RedirectToPage("Index");
                }
                else
                { 
                    _INotyfService.Warning("Su formulario no cumple con los requisitos");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                _INotyfService.Error("Ocurrió un error en el servidor, intente nuevamente");
                return RedirectToPage("Index");
            }
        }
    }
}
