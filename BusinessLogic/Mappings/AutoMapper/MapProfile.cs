using AutoMapper;
using BusinessLogic.Models.CategoryModels;
using Entity.Concrete.Customer;

namespace BusinessLogic.Mappings.AutoMapper;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<CategoryModel,Category>().ReverseMap();
       
    }
}
