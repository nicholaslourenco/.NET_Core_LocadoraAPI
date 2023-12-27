using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using LocadoraAPI.Models;
using LocadoraAPI.Controllers;
using Microsoft.AspNetCore.JsonPatch;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("locadora/api/[controller]")]
    public class LocacaoController : ControllerBase
    {

        // Listagem de Locações

        [HttpGet("tipoFiltro-filtro")]
        public IActionResult Listar([FromQuery(Name = "tipoFiltro")] string tipoFiltro, [FromQuery(Name = "filtro")] string filtro)
        {
            try
            {
                FiltroLocacao empFiltro = null;
                if (!string.IsNullOrEmpty(filtro))
                {
                    empFiltro = new FiltroLocacao();
                    empFiltro.Filtro = filtro;
                    empFiltro.TipoFiltro = tipoFiltro;
                }

                LocacaoService service = new LocacaoService();
                return Ok(service.Listar(empFiltro));
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha ao processar dados.");
            }
        }

        [HttpGet("id")]
        public IActionResult BuscaId([FromQuery(Name = "id")] int id)
        {
            try
            {

                LocacaoService locacaoService = new LocacaoService();
                Locacao locacaoAchada = locacaoService.BuscaId(id);
                return Ok(locacaoAchada);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha ao processar dados.");
            }
            
        }

        // Cadastro de Locações

        [HttpPost]
        public IActionResult Cadastro(Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            new LocacaoService().Inserir(locacao);
            return Ok("Locação realizada com sucesso!");
        }

        // Edição de Locações

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Locacao locacao)
        {
            LocacaoService ls = new LocacaoService();
            ls.Editar(id, locacao);
            return Ok("Locação atualizada com sucesso!");
        }

        // Exclusão de Locações

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            new LocacaoService().Excluir(id);
            return Ok("Exclusão feita com sucesso!");
        }

    }
}