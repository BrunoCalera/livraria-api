using System.ComponentModel.DataAnnotations;

namespace livraria_api.Dtos
{
    public class LivroCreateDto
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        [MaxLength(100, ErrorMessage = "O título pode ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório")]
        [MaxLength(70, ErrorMessage = "O autor pode ter no máximo 70 caracteres.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório")]
        [MaxLength(30, ErrorMessage = "O gênero pode ter no máximo 30 caracteres.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo")]
        public int? Estoque { get; set; }
    }
}
