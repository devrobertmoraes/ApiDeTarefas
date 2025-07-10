using ApiDeTarefas.Entities;

namespace ApiDeTarefas.Repositories
{
    public interface ITarefaRepository
    {
        void Adicionar(Tarefa tarefa);
        Tarefa ObterPorId(int id);
        List<Tarefa> ObterTodos();
        void Atualizar(Tarefa tarefa);
        void Remover(int id);
    }
}
