using AutoMapper;
using AxityStoreBackEnd.Domain.DTO;
using AxityStoreBackEnd.Domain.Entities;

namespace AxityStoreBackEnd.Infrastructure.Data.Mapping
{
    public class DataProfile: Profile
    {
        public DataProfile()
        {
            CreateMap<User, DTOUser>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUsuario))
                                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nombre))
                                      .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Apellido))
                                      .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsActivo))
                                      .ReverseMap();

            CreateMap<Product, DTOProduct>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProducto))
                                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Producto))
                                            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Cantidad))
                                            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Precio))
                                            .ReverseMap();
        }
    }
}
