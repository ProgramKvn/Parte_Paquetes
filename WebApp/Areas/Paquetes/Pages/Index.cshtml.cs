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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Areas.Paquetes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyRepository<Paquete> _repository;
        private readonly MyRepository<Registro_Pago> _repositoryPago;
        public INotyfService _notyfService { get; }
        private readonly IAppLogger<UpdateModel> _logger;
        public IndexModel(MyRepository<Paquete> repository, INotyfService notyfService, IAppLogger<UpdateModel> logger, MyRepository<Registro_Pago> repositoryPago)
        {
            _repository = repository;
            _notyfService = notyfService;
            _logger = logger;
            _repositoryPago = repositoryPago;
        }
        [BindProperty]
        public Paquete Paquete { get; set; }
        [BindProperty]
        public Registro_Pago Registro_Pago { get; set; }
        public List<Paquete> Paquetes { get; set; }
        public UIPaginationModel UIPagination { get; set; }
        public async Task OnGetAsync(string searchString, int? currentPage, int? sizePage)
        {
            var totalItems = await _repository.CountAsync(new Paquete_Spec(new Paquete_Filter { Contenido_Paquete = searchString, LoadChildren = false, IsPagingEnabled = true }));
            UIPagination = new UIPaginationModel(currentPage, searchString, sizePage, totalItems);

            Paquetes = await _repository.ListAsync(new Paquete_Spec(
                new Paquete_Filter
                { 
                    IsPagingEnabled = true,
                    Contenido_Paquete = UIPagination.SearchString,
                    SizePage = UIPagination.GetSizePage,
                    Page = UIPagination.GetCurrentPage
                })
                );
        }
        public async Task<JsonResult> OnGetSelect(int Id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
        }
        public async Task<JsonResult> OnPostEliminar(int Id)
        {
            try
            {
                var paquete = await _repository.GetByIdAsync(Id);
                if(paquete == null)
                {
                    _notyfService.Warning($"El paquete, con id {Id}, no ha sido encontrado.");
                    return new JsonResult(new { deleted = false });
                }
                await _repository.DeleteAsync(paquete);
                return new JsonResult(new { deleted = true });
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new JsonResult(new { deleted = false });
            }
        }
        public async Task<JsonResult> OnPostPagar(int Id)
        {
            try
            {
                var paquete = await _repository.GetByIdAsync(Id);
                if (paquete == null)
                {
                    _notyfService.Warning($"El paquete, con id {Id}, no ha sido encontrado.");
                    return new JsonResult(new { pago = false });
                }
                paquete.Estado_Pago = true;
                paquete.Estado_Paquete = "En chequeo";

                Registro_Pago.PaqueteId = paquete.Id;
                Registro_Pago.Monto_Pagado = paquete.Monto_Pagar_Prop;

                await _repositoryPago.AddAsync(Registro_Pago);

                RedirectToPage("Index");

                return new JsonResult(new { pago = true });
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new JsonResult(new { deleted = false });
            }
        }
    }
}
