using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.DTO
{
    public class ContatoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Excedeu o número máximo de caracteres")]
        [MinLength(3, ErrorMessage = "Insira no mínimo 3 caracteres para o nome")]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Excedeu o número máximo de caracteres")]
        [MinLength(3, ErrorMessage = "Insira no mínimo 3 caracteres para o sobrenome")]
        public string Sobrenome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de celular é obrigatório")]
        public int Celular { get; set; }
        public int Telefone { get; set; }

        [Required(ErrorMessage = "O campo favorito é obrigatório")]
        [MaxLength(1)]
        [MinLength(1)]
        public char Favorito { get; set; } = 'N';
    }
}
