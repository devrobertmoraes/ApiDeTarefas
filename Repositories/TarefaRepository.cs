using ApiDeTarefas.Entities;

namespace ApiDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private static readonly List<Tarefa> _tarefas = new List<Tarefa>();

        private static int _nextId = 1;

        public void Adicionar(Tarefa tarefa)
        {
            tarefa.Id = _nextId++;
            _tarefas.Add(tarefa);
        }

        public void Atualizar(Tarefa tarefaAtualizada)
        {
            Tarefa tarefaExistente = ObterPorId(tarefaAtualizada.Id);

            if (tarefaExistente != null)
            {
                tarefaExistente.Titulo = tarefaAtualizada.Titulo;
                tarefaExistente.Concluida = tarefaAtualizada.Concluida;
            }
        }

        public Tarefa ObterPorId(int id)
        {
            return _tarefas.FirstOrDefault(t => t.Id == id);
        }

        public List<Tarefa> ObterTodos()
        {
            return _tarefas.ToList();
        }

        public void Remover(int id)
        {
            Tarefa tarefaParaRemover = ObterPorId(id);

            if (tarefaParaRemover != null)
            {
                _tarefas.Remove(tarefaParaRemover);
            }
        }
    }
}
