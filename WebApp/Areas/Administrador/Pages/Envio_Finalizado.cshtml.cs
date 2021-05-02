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

namespace WebApp.Areas.Administrador.Pages
{
    public class Envio_FinalizadoModel : PageModel
    {
        private readonly MyRepository<Paquete> _repository;

        public Envio_FinalizadoModel(MyRepository<Paquete> repository)
        {
            _repository = repository;
        }
        public List<Paquete> Paquetes { get; set; }
        public async Task OnGetAsync()
        {
            Paquetes = await _repository.ListAsync(new Estado_Spec(new Paquete_Filter { Estado_Paquete = "Envio finalizado" }));
        }
    }
}
