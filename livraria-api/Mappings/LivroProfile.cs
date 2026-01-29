using AutoMapper;
using livraria_api.Dtos;
using livraria_api.Models;

namespace livraria_api.Mappings
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<LivroCreateDto, Livro>();
        }
    }
}
