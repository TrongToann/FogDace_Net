using AutoMapper;
using Contract.DTOs.AccountDTO;
using Contract.DTOs.Auth;
using Contract.DTOs.BlogDTO;
using Contract.DTOs.CartDTO;
using Contract.DTOs.OrderDTO;
using Contract.DTOs.PetDTO;
using Contract.DTOs.PetHealthProfileDTO;
using Contract.DTOs.PetTypeDTO;
using Contract.DTOs.ProductDTO;
using Contract.DTOs.RoleDTO;
using Contract.Service.Role;
namespace Application.Mapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile() {
            //Auth
            CreateMap<Domain.Entities.Account, CreateAccountDTO>().ReverseMap();
            CreateMap<Domain.Entities.Account, AccountDTO>().ReverseMap();
            CreateMap<Domain.Entities.Account, RegisterDTO>().ReverseMap();
            //Pet
            CreateMap<Domain.Entities.Pet, UpdatePetDTO>().ReverseMap();
            CreateMap<Domain.Entities.Pet, CreatePetDTO>().ReverseMap();
            CreateMap<Domain.Entities.Pet, Contract.Service.Pet.Response>().ReverseMap().MaxDepth(1).PreserveReferences();
            CreateMap< IEnumerable <Domain.Entities.Pet> , List<Contract.Service.Pet.Response>>().ReverseMap();

            //Pet Health Profile
            CreateMap<Domain.Entities.PetHealthProfile, CreatePetHealthProfileDTO>()
                .ReverseMap();
            CreateMap<Domain.Entities.PetHealthProfile, UpdatePetHealthProfileDTO>().ReverseMap();
            CreateMap<Domain.Entities.PetHealthProfile, Contract.Service.PetHealthProfile.Response>().ReverseMap().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.TiemPhong, TiemPhongDTO>().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.TinhCach, TinhCachDTO>().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.TinhTrangSK, TinhTrangSKDTO>().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.XoGiun, XoGiunDTO>().MaxDepth(1).PreserveReferences();

            CreateMap<Domain.Entities.PetHealthProfile, Contract.Service.PetHealthProfile.Response>().ReverseMap().MaxDepth(1).PreserveReferences(); ;
            CreateMap<Domain.Entities.TiemPhong, TiemPhongDTO>().MaxDepth(1).PreserveReferences(); ;
            CreateMap<Domain.Entities.TinhCach, TinhCachDTO>().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.TinhTrangSK, TinhTrangSKDTO>().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.XoGiun, XoGiunDTO>().MaxDepth(1).PreserveReferences();
            //Product
            CreateMap<Domain.Entities.Product, ProductDTO>().ReverseMap();
            CreateMap<Domain.Entities.Product, Contract.Service.Product.Response>().ReverseMap();
            CreateMap<IEnumerable<Domain.Entities.Product>, List<Contract.Service.Product.Response>>().ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductDTO>().ReverseMap();
            //Blog
            CreateMap<Domain.Entities.Blog, CreateBlogDTO>().ReverseMap();
            //PetType
            CreateMap<Domain.Entities.PetType, CreatePetTypeDTO>().ReverseMap();
            //Order
            CreateMap<Domain.Entities.Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Domain.Entities.Order, Contract.Service.Order.Response>().ReverseMap().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.OrderProducts, OrderProduct>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product)).MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.OrderShipping, InputOrderShipping>().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.OrderStatus, OrderStatus>().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.OrderStatus, InputOrderStatus>().MaxDepth(1).PreserveReferences();
            //Role
            CreateMap<Domain.Entities.Role, CreateRoleDTO>().ReverseMap();
            CreateMap<Domain.Entities.Role, Response>().ReverseMap();
            //Cart
            CreateMap<Domain.Entities.Cart, Contract.Service.Cart.Response>().ReverseMap().MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.CartProduct, CartProductDTO>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product)).MaxDepth(1).PreserveReferences();
            CreateMap<Domain.Entities.Cart, ICartDTO>().ReverseMap();
            CreateMap<Domain.Entities.Cart, Contract.Service.Cart.Response>().ReverseMap().MaxDepth(1).PreserveReferences();
        }
    }
}
