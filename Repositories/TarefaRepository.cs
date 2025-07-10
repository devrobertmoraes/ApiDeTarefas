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
        }
    }
}
