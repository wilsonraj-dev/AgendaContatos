using AgendaContatos.DTO;
using AgendaContatos.Entities;
using AutoMapper;

namespace AgendaContatos.Mappings
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<Contato, ContatoDTO>().ReverseMap();
        }
    }
}
