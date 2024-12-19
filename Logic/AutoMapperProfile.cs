using AutoMapper;
using DataTransferObjects;
using Entities;

namespace Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            /// *************************************************** 
            /// Configuracion de mapeos modelo y entidad Person
            /// *************************************************** 
            CreateMap<PersonDto, Person>()
                .ReverseMap();
        }
    }
}
