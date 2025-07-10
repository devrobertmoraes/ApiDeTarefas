document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = '/api/tarefas';
    const taskForm = document.getElementById('new-task-form');
    const taskTitleInput = document.getElementById('task-title');
    const taskList = document.getElementById('task-list');

    async function fetchTarefas() {
        try {
            const response = await fetch(apiUrl);
            const tarefas = await response.json();

            taskList.innerHTML = '';
            tarefas.forEach(tarefa => renderTarefa(tarefa));
        } catch (error) {
            console.error('Erro ao buscar tarefas: ', error);
        }
    }

    function renderTarefa(tarefa) {
        const li = document.createElement('li');
        li.dataset.id = tarefa.id;

        if (tarefa.concluida) {
            li.classList.add('completed');
        }

        const span = document.createElement('span');
        span.textContent = tarefa.titulo;

        const deleteButton = createElement('button');
        deleteButton.textContent = 'X';

        li.appendChild(span);
        li.appendChild(deleteButton);
        taskList.appendChild(li);

        li.addEventListener('click', async () => {
            await toggleTarefa(tarefa.id, !tarefa.concluida, tarefa.titulo);
        });

        deleteButton.addEventListener('click', async (e) => {
            e.stopPropagation();
            await deleteTarefa(tarefa.id);
        });
    }

    taskForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        const titulo = taskTitleInput.value

        if (!titulo) return;

        try {
            const response = await fetch(apiUrl, {
                method: 'POST',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify({titulo: titulo})
            });

            if (responde.ok) {
                taskTitleInput.value = '';
                fetchTarefas();
            }
        } catch (error) {
            console.error('Erro ao adicionar tarefa:', error);
        }
    });

    async function toggleTarefa(id, concluida, titulo) {
        try {
            await fetch(`${apiUrl}/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ titulo: titulo, concluida: concluida })
            });
            fetchTarefas();
        } catch (error) {
            console.error('Erro ao atualizar tarefa:', error);
        }
    }

    async function deleteTarefa(id) {
        try {
            await fetch(`${apiUrl}/${id}`, { method: 'DELETE' });
            fetchTarefas();
        } catch (error) {
            console.error('Erro ao deletar tarefa:', error);
        }
    }

    fetchTarefas();
});