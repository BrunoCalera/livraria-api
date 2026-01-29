using System.ComponentModel.DataAnnotations;

namespace livraria_api.Models
{
    public class Livro
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório")]
        public string Genero { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo")]
        public int Estoque { get; set; }
    }
}
