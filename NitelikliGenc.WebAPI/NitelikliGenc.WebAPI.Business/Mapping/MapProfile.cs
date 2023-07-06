using AutoMapper;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Product, ProductForListDto>().ForMember(dest => dest.Price,
            opt => opt.MapFrom(src => $"{src.Price} {src.Currency}"));
        
        CreateMap<Product, ProductForDetailDto>().ReverseMap();
        CreateMap<Category, CategoryForPostDto>().ReverseMap();
        CreateMap<Product, ProductForPostDto>().ReverseMap();
        CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        CreateMap<Product, ProductForUpdateDto>().ReverseMap();
        CreateMap<Comment, CommentForPostDto>().ReverseMap();
        CreateMap<Product, ProductForSummaryDto>().ReverseMap();
        CreateMap<Comment, CommentForDetailDto>().ReverseMap();
        CreateMap<Comment, ProductsForCommentById>().ReverseMap();
        CreateMap<Comment, CommentForUpdateDto>().ReverseMap();
    }
    
}