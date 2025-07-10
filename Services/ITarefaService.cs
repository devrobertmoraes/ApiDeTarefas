using ApiDeTarefas.Entities;

namespace ApiDeTarefas.Services
{
    public interface ITarefaService
    {
        Tarefa CriarTarefa(string titulo);
        List<Tarefa> ObterTodas();
        Tarefa ObterPorId(int id);
        void MarcarComoConcluida(int id, bool concluida);
        bool RemoverTarefa(int id);
    }
}
