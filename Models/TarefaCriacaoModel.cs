using System.ComponentModel.DataAnnotations;

namespace ApiDeTarefas.Models
{
    public class TarefaCriacaoModel
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }
    }
}
