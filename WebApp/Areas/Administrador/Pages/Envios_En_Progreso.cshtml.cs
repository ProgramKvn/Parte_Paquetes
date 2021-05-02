using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specification;
using ApplicationCore.Specification.Filters;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Areas.Administrador.Pages
{
    [Authorize(Roles = "Admin")]
    public class Envios_En_ProgresoModel : PageModel
    {
        private readonly MyRepository<Paquete> _repository;
        private INotyfService _notyfService { get; }
        private readonly IAppLogger<Envios_En_ProgresoModel> _logger;

        public Envios_En_ProgresoModel(IAppLogger<Envios_En_ProgresoModel> logger, MyRepository<Paquete> repository, INotyfService notyfService)
        {
            _logger = logger;
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public Paquete Paquete { get; set; }
        public List<Paquete> Paquetes { get; set; }
        public async Task OnGetAsync()
        {
            Paquetes = await _repository.ListAsync(new Estado_Spec(new Paquete_Filter { Estado_Paquete = "En progreso" }));
        }
        public async Task<JsonResult> OnPostEntregar(int Id)
        {
            var paquete = await _repository.GetByIdAsync(Id);
            if (paquete == null)
            {
                _notyfService.Warning($"El paquete, con id {Id}, no ha sido encontrado.");
                return new JsonResult( new { aceptar = true });
            }
            paquete.Estado_Paquete = "Envio finalizado";
            await _repository.UpdateAsync(paquete);
            return new JsonResult(new { aceptar = false});
        }
    }
}
