using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using LocadoraAPI.Models;
using LocadoraAPI.Controllers;
using Microsoft.AspNetCore.JsonPatch;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("locadora/api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        // Listagem de Usuários

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(new UsuarioService().Listar());
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
                UsuarioService userService = new UsuarioService();
                Usuario userAchado = userService.BuscaId(id);
                return Ok(userAchado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha ao processar dados.");
            }
            
        }

        // Cadastro de Usuários

        [HttpPost]
        public IActionResult Cadastro(Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //user.Senha = Criptografo.TextoCriptografado(user.Senha);
            new UsuarioService().Inserir(user);
            return Ok("Usuário " + user.Nome + " cadastrado com sucesso!");
        }

        // Edição de Usuários

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Usuario usuario)
        {
            UsuarioService us = new UsuarioService();
            //usuario.Senha = Criptografo.TextoCriptografado(usuario.Senha);
            us.Editar(id, usuario);
            return Ok("Usuário atualizado com sucesso!");
        }

        // Exclusão de Usuários

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            new UsuarioService().Excluir(id);
            return Ok("Exclusão feita com sucesso!");
        }

    }
}