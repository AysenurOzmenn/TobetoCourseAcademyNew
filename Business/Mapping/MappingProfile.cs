using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CreateCourseRequest>().ReverseMap();
            CreateMap<Course, CreatedCategoryResponse>().ReverseMap();
            CreateMap<Course, GetListedCourseResponse>().ReverseMap();
            CreateMap<IPaginate<Course>, IPaginate<GetListedCourseResponse>>().ReverseMap();

            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
            CreateMap<Category, GetListedCategoryResponse>().ReverseMap();
            CreateMap<IPaginate<Category>, IPaginate<GetListedCategoryResponse>>().ReverseMap();

            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetListedInstructorResponse>().ReverseMap();
            CreateMap<IPaginate<Instructor>, IPaginate<GetListedInstructorResponse>>().ReverseMap();
        }
    }
}
