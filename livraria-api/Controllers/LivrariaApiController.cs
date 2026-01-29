using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace livraria_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaApiController : ControllerBase
    {
        protected readonly IMapper _mapper;

        protected LivrariaApiController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
