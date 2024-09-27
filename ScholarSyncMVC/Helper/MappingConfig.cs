using AutoMapper;
using ScholarSyncMVC.Models;
using ScholarSyncMVC.ViewModels;

namespace ScholarSyncMVC.Helper
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Category, CategoryCreatedVM>().ReverseMap();

        }
    }
}
