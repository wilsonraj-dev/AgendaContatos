using AgendaContatos.Validation;

namespace AgendaContatos.Entities
{
    public sealed class Contato : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public int Celular { get; set; }
        public int Telefone { get; set; }
        public char Favorito { get; set; } = 'N';

        public Contato(int id, string nome, string sobrenome, int celular, int telefone, char favorito)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido");
            Id = id;

            ValidateDomain(nome, sobrenome, celular, telefone, favorito);
        }

        public Contato(string nome, string sobrenome, int celular, int telefone, char favorito)
        {
            ValidateDomain(nome, sobrenome, celular, telefone, favorito);
        }

        private void ValidateDomain(string nome, string sobrenome, int celular, int telefone, char favorito)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório");
            DomainExceptionValidation.When(celular < 0, "Número de celular inválido");
            DomainExceptionValidation.When(celular == 0, "Número de celular inválido");

            Nome = nome;
            Sobrenome = sobrenome;
            Celular = celular;
            Telefone = telefone;
            Favorito = favorito;
        }
    }
}
