using ApiDeTarefas.Entities;
using ApiDeTarefas.Models;

namespace ApiDeTarefas.Services
{
    public interface ITarefaService
    {
        Tarefa CriarTarefa(string titulo);
        List<Tarefa> ObterTodas();
        Tarefa ObterPorId(int id);
        Tarefa AtualizarTarefa(int id, TarefaAtualizacaoModel model);
        bool RemoverTarefa(int id);
    }
}
