using AutoMapper;
using Shared.ViewModels.Category;
using Shared.ViewModels.Product;

namespace Services.Mappings
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductCreateViewModel,Product>()
                .ForMember(dest => dest.ImagePath,opt => opt.Ignore());

            CreateMap<Category,CategoryViewModel>();
            CreateMap<Product,ProductViewModel>()
    .ForMember(dest => dest.CategoryName,opt => opt.MapFrom(src => src.Category.Name));
           

            CreateMap<ProductEditViewModel,Product>()
                .ForMember(dest => dest.ImagePath,opt => opt.Ignore()) 
                .ForMember(dest => dest.CreatedAt,opt => opt.Ignore()) 
                .ForMember(dest => dest.CreatedByUserId,opt => opt.Ignore());
        }
    }
}
