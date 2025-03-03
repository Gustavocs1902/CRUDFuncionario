using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly BancoDB _db;
        public FuncionariosController(BancoDB db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpPost("incluir")] // Rota: api/Funcionarios/incluir
        public IActionResult Adicionar([FromBody] FuncionariosDb funcionario)
        {
            if (funcionario == null) return BadRequest("Funcionario Não Enviado");

            try
            {
                _db.Funcionario.Add(funcionario);
                _db.SaveChanges();
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar funcionário: {ex.Message}");
            }
        }


        [HttpGet("Listar")]
        public IActionResult Listar(String? nome)
        {
            try
            {
                var query = _db.Funcionario.AsQueryable();

                if (!String.IsNullOrEmpty(nome))
                {
                    query = query.Where(e => e.Nome.ToUpper().Contains(nome.ToUpper()));
                }

                var retorno = query.ToList();

                if (retorno.Count == 0)
                {
                    return NotFound("Nenhum funcionário encontrado");
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao listar os funcionarios: {ex.Message}");
            }
        }

        [HttpGet("consultar/{id:int}")]
        public IActionResult Consultar(int id)
        {
            if (id <= 0) return BadRequest("Id Inválido");

            try
            {
                var funcionario = _db.Funcionario.FirstOrDefault(e => e.Id == id);

                if (funcionario == null)
                {
                    return NotFound("Funcionario não encontrado");
                }

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao consultar funcionário: {ex.Message}");
            }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar(FuncionariosDb funcionario)
        {
            if (funcionario == null || funcionario.Id <= 0)
            {
                return BadRequest("Dados inválidos.");
            }
            try
            {
                var funcionarioExistente = _db.Funcionario.FirstOrDefault(e => e.Id == funcionario.Id);

                if (funcionarioExistente == null)
                {
                    return NotFound("Funcionario não encontrado");
                }

                funcionarioExistente.Nome = funcionario.Nome;
                funcionarioExistente.Telefone = funcionario.Telefone;
                funcionarioExistente.RG = funcionario.RG;
                funcionarioExistente.Endereco = funcionario.Endereco;
                funcionarioExistente.Salario = funcionario.Salario;
                funcionarioExistente.HorasExtras = funcionario.HorasExtras;

                _db.SaveChanges();
                return Ok(funcionarioExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao alterar funcionário: {ex.Message}");
            }
        }

        [HttpDelete("excluir/{id:int}")]
        public IActionResult Excluir(int id)
        {
            if (id <= 0) return BadRequest("Id inválidp");

            try
            {
                var funcionario = _db.Funcionario.FirstOrDefault(e => e.Id == id);

                if (funcionario == null)
                {
                    return BadRequest("Funcionario não encontrado");
                }

                _db.Funcionario.Remove(funcionario);
                _db.SaveChanges();

                return Ok("Funcionario excluido");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir funcionario: {ex.Message}");
            }
        }
    }
}

