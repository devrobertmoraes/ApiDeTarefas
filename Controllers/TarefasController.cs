using ApiDeTarefas.Entities;
using ApiDeTarefas.Models;
using ApiDeTarefas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiDeTarefas.Controllers
{
    [ApiController]
    [Route("api/tarefas")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        // GET: api/tarefas
        [HttpGet]
        public ActionResult<List<Tarefa>> GetTodas()
        {
            List<Tarefa> tarefas = _tarefaService.ObterTodas();
            return Ok(tarefas);
        }

        // GET: api/tarefas/5
        [HttpGet("{id}")]
        public ActionResult<Tarefa> GetPorId(int id)
        {
            Tarefa tarefa = _tarefaService.ObterPorId(id);

            if (tarefa == null)
            {
                return NotFound(); // 404
            }

            return Ok(tarefa);
        }

        // POST: api/tarefas
        [HttpPost]
        public ActionResult<Tarefa> Criar([FromBody] TarefaCriacaoModel model)
        {
            Tarefa tarefa = _tarefaService.CriarTarefa(model.Titulo);

            return CreatedAtAction(nameof(GetPorId), new { id = tarefa.Id }, tarefa);
        }

        //PUT: api/tarefas/5
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] TarefaAtualizacaoModel model)
        {
            Tarefa tarefaAtualizada = _tarefaService.AtualizarTarefa(id, model);

            if (tarefaAtualizada == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        //DELETE: api/tarefas/5
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            bool sucesso = _tarefaService.RemoverTarefa(id);

            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
