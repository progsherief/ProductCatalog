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


        }
    }
}
