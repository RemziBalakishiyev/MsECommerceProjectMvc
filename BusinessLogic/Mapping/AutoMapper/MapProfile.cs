using AutoMapper;
using BusinessLogic.Models;
using Entity.Concrete.Customer;

namespace BusinessLogic.Mapping.AutoMapper;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<CategoryModel, Category>().ReverseMap();
    }
}
