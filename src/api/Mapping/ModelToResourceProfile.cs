using api.Domain.Models;
using api.Domain.Models.Queries;
using api.Models;
using api.Resources;
using AutoMapper;

namespace api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Cliente, ClienteResource>();
            CreateMap<SaveClienteResource, Cliente>();

            CreateMap<Logradouro, LogradouroResource>();
            CreateMap<SaveLogradouroResource, Logradouro>();

            CreateMap<QueryResult<Cliente>, QueryResultResource<ClienteResource>>();
            CreateMap<ClientesQueryResource, ClientesQuery>();
        }
    }
}
