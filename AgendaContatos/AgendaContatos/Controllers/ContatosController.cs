using AgendaContatos.DTO;
using AgendaContatos.Entities;
using AgendaContatos.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatosController(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("todos-contatos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> GetContatos()
        {
            var contatos = await _contatoRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<ContatoDTO>>(contatos));
        }

        [HttpGet]
        [Route("contatos-por-nome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> GetContatosPeloNome(string nome)
        {
            var contatos = await _contatoRepository.GetContatosPeloNome(nome);

            if (!contatos.Any())
            {
                return NotFound("Nenhum contato encontrado");
            }

            return Ok(_mapper.Map<IEnumerable<ContatoDTO>>(contatos));
        }

        [HttpGet]
        [Route("contatos-favoritos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> GetContatosFavoritos()
        {
            var favoritos = await _contatoRepository.GetContatosFavoritos();

            if (!favoritos.Any())
            {
                return NotFound("Você não tem nenhum contato marcado como favorito");
            }

            return Ok(_mapper.Map<IEnumerable<ContatoDTO>>(favoritos));
        }

        [HttpPost]
        [Route("add-contato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddContatoAsync([FromBody] ContatoDTO contatoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inconsistentes foram detectados");
            }

            await _contatoRepository.AddAsync(_mapper.Map<Contato>(contatoDTO));
            return Ok(_mapper.Map<Contato>(contatoDTO));
        }

        [HttpPut]
        [Route("update-contato/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateContatosAsync([FromBody] ContatoDTO contatoDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else if (id != contatoDTO.Id)
            {
                return BadRequest();
            }

            await _contatoRepository.UpdateAsync(_mapper.Map<Contato>(contatoDTO));
            return Ok(contatoDTO);
        }

        [HttpDelete]
        [Route("remove-contato/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var contato = await _contatoRepository.GetContatoPeloId(id);

            if (contato is null)
            {
                return BadRequest();
            }

            await _contatoRepository.RemoveAsync(contato.Id);
            return NoContent();
        }
    }
}
