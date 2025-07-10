using ApiDeTarefas.Entities;
using ApiDeTarefas.Repositories;
using ApiDeTarefas.Models;

namespace ApiDeTarefas.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public Tarefa CriarTarefa(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                return null;
            }

            Tarefa novaTarefa = new Tarefa
            {
                Titulo = titulo,
                Concluida = false
            };

            _tarefaRepository.Adicionar(novaTarefa);

            return novaTarefa;
        }

        public List<Tarefa> ObterTodas()
        {
            return _tarefaRepository.ObterTodos();
        }

        public Tarefa ObterPorId(int id)
        {
            return _tarefaRepository.ObterPorId(id);
        }

        public Tarefa AtualizarTarefa(int id, TarefaAtualizacaoModel model)
        {
            Tarefa tarefaExistente = _tarefaRepository.ObterPorId(id);

            if (tarefaExistente == null)
            {
                return null;
            }

            tarefaExistente.Titulo = model.Titulo;
            tarefaExistente.Concluida = model.Concluida;

            _tarefaRepository.Atualizar(tarefaExistente);

            return tarefaExistente;
        }

        public bool RemoverTarefa(int id)
        {
            Tarefa tarefaExistente = _tarefaRepository.ObterPorId(id);

            if (tarefaExistente != null)
            {
                _tarefaRepository.Remover(id);
                return true;
            }

            return false;
        }
    }
}
