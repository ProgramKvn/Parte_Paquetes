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
    public class IndexModel : PageModel
    {
        private readonly MyRepository<Paquete> _repository;
        public INotyfService _notyfService { get; }
        private readonly IAppLogger<IndexModel> _logger;
        public IndexModel(MyRepository<Paquete> repository, INotyfService notyfService, IAppLogger<IndexModel> logger)
        {
            _repository = repository;
            _notyfService = notyfService;
            _logger = logger;
        }
        public Paquete Paquete { get; set; }
        public List<Paquete> Paquetes { get; set; }
        public async Task OnGetAsync()
        {
            Paquetes = await _repository.ListAsync(new Estado_Spec(new Paquete_Filter { Estado_Paquete = "En chequeo" }));
        }
        public async Task<JsonResult> OnGetDetalles(int Id)
        {
            var paquete = await _repository.GetByIdAsync(Id);
            if (paquete == null)
            {
                _notyfService.Warning($"El paquete, con id {Id}, no ha sido encontrado.");
                return new JsonResult(new { seleccionado = false });
            }
            Paquete = paquete;
            return new JsonResult(new
            {
                info = Paquete,
                Nombre_Fotografia = Paquete.Nombre_Fotografia()
            });
        }
        public async Task<JsonResult> OnPostAceptar(int Id)
        {
            var paquete = await _repository.GetByIdAsync(Id);
            if (paquete == null)
            {
                _notyfService.Warning($"El paquete, con id {Id}, no ha sido encontrado.");
                return new JsonResult(new { aceptado = false });
            }
            paquete.Estado_Paquete = "En progreso";
            await _repository.UpdateAsync(paquete);
            return new JsonResult(new { aceptado = true });
        }
        public async Task<JsonResult> OnPostRechazar(int Id)
        {
            var paquete = await _repository.GetByIdAsync(Id);
            if (paquete == null)
            {
                _notyfService.Warning($"El paquete, con id {Id}, no ha sido encontrado.");
                return new JsonResult(new { rechazado = false });
            }
            paquete.Estado_Paquete = "Rechazado";
            await _repository.UpdateAsync(paquete);
            return new JsonResult(new { rechazado = true });
        }
    }
}

