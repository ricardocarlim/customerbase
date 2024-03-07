using api.Domain.Models;
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
        }
    }
}
