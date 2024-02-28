using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using LocadoraAPI.Models;
using LocadoraAPI.Controllers;
using Microsoft.AspNetCore.JsonPatch;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("locadora/api/[controller]")]
    public class FilmeController : ControllerBase
    {

        // Listagem de Filmes

        [HttpGet("tipoFiltro-filtro")]
        public IActionResult Listar([FromQuery(Name = "tipoFiltro")] string tipoFiltro, [FromQuery(Name = "filtro")] string filtro)
        {
            try
            {
                FiltroFilme filtroFilme = null;

                if (!string.IsNullOrEmpty(filtro))
                {
                    filtroFilme = new FiltroFilme
                    {
                        Filtro = filtro,
                        TipoFiltro = tipoFiltro
                    };
                }

                FilmesService filmesService = new FilmesService();
                List<Filme> listaDeFilmes = filmesService.Listar(filtroFilme);
                return Ok(listaDeFilmes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha ao processar dados.");
            }
            
        }

        // Busca Filmes por Id

        [HttpGet("id")]
        public IActionResult BuscaId([FromQuery(Name = "id")] int id)
        {
            try
            {
                FiltroFilme filtroFilme = null;

                FilmesService filmesService = new FilmesService();
                Filme filmeAchado = filmesService.BuscaId(id);
                return Ok(filmeAchado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha ao processar dados.");
            }
            
        }

        // Cadastro de Filmes

        [HttpPost]
        public IActionResult Cadastro(Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            new FilmesService().Inserir(filme);
            return Ok(Listar(null, null));
        }

        // Edição de Filmes

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Filme filme)
        {
            FilmesService fm = new FilmesService();
            fm.Editar(id, filme);
            return Ok(Listar(null, null));
        }

        // Exclusão de Filmes

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            new FilmesService().Excluir(id);
            return Ok(id);
        }

    }
}