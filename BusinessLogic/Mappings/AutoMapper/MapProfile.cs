using AutoMapper;
using BusinessLogic.Models.CategoryModels;
using BusinessLogic.Models.ProductModels;
using Entity.Concrete;
using Entity.Concrete.Customer;

namespace BusinessLogic.Mappings.AutoMapper;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<CategoryModel,Category>().ReverseMap();

        CreateMap<Color, ColorModel>().ReverseMap();

        CreateMap<ProductModel, Product>().ReverseMap();
        CreateMap<Product, GetAllProduct>()
            .ForMember(x => x.InStock, opt => opt.MapFrom(s => s.InStock ? "Stokda var" : "Stokda yoxdur"))
            .ReverseMap();
            

    }
}
