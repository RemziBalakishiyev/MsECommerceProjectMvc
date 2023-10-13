using AutoMapper;
using BusinessLogic.Models;
using Entity.Concrete;
using Entity.Concrete.Customer;

namespace BusinessLogic.Mapping.AutoMapper;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<CategoryModel, Category>().ReverseMap();
        CreateMap<ColorModel, Color>().ReverseMap();

        CreateMap<AddProductModel, Product>()
            .ForMember(x=>x.Colors,opt=>opt.MapFrom(x=>x.ColorModels));
    }
}
