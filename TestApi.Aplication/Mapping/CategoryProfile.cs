namespace TestApi.Aplication.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoryDto>()
                .ForMember(dest => dest.CategoryId, src => src.MapFrom(c => c.Id))
                .ForMember(dest => dest.CategoryName, src => src.MapFrom(c => c.Name))
                .ReverseMap();

            CreateMap<CreateCategoryDto, Category>()
                .ForMember(dest => dest.Name, src => src.MapFrom(c => c.CategoryName))
                .ReverseMap();

            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(dest => dest.Name, src => src.MapFrom(c => c.Name))
                .ReverseMap();

            CreateMap<Category, GetCategoryWithProductsDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}
