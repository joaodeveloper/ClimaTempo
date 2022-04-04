using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace ClimaTempoSimples.Controllers
{
    using ClimaTempoSimples.Abstractions.Services;
    using ClimaTempoSimples.Models;

    public class HomeController : Controller
    {
        private readonly ICidadeService _cidadeService;
        private readonly IPrevisaoClimaService _previsaoClimaService;
        private IEnumerable<Cidade> cidades;

        public HomeController(ICidadeService cidadeService, IPrevisaoClimaService previsaoClimaService)
        {
            _cidadeService = cidadeService;
            _previsaoClimaService = previsaoClimaService;
        }

        public async Task<ActionResult> Index()
        {
            cidades = await _cidadeService.ListarTodasAsync();
            List<SelectListItem> items = (from item in cidades
                                          select new SelectListItem() 
                                           { 
                                               Value = item.Id.ToString(), 
                                               Text = item.Nome 
                                           }
                                         ).ToList();
            ViewBag.Cidades = items;

            ViewBag.CidadesMaisQuentes = await _previsaoClimaService.ObterTresCidadesMaisQuentes();

            ViewBag.CidadesMaisFrias = await _previsaoClimaService.ObterTresCidadesMaisFrias();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ObeterPrevisaoSemanal(string idCidade)
        {
            var previsoes = await _previsaoClimaService.ObterPrevisaoSemanalCidade(Convert.ToInt32(idCidade));
            return Json(from item in previsoes
                            select new
                            {
                                DiaSemana = item.DataPrevisao.DayOfWeek.ToString(),
                                item.Clima,
                                item.TemperaturaMaxima,
                                item.TemperaturaMinima
                            }
                       );
        }
        public ActionResult About()
        {
            return View();
        }
    }
}