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
            CreateMap<UniversityVM, University>().ReverseMap();
            CreateMap<Scholarship, ScholarshipVM>().ReverseMap();
            CreateMap<Country, CountryVM>().ReverseMap();
            CreateMap<Country, CounryEditVM>().ReverseMap();
            CreateMap<Requirements, RequirementVM>().ReverseMap();




        }
    }
}
