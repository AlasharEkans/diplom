using AutoMapper;
using BL.DTO;
using Core.Models;
using System.Linq;

namespace BL.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Course, CourseDTO>().ReverseMap();
        CreateMap<Student, StudentDTO>().ReverseMap();
        CreateMap<Cart, CartDTO>().ReverseMap();

        CreateMap<Enrollment, EnrollmentDTO>()
            .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.EnrollmentCourses.Select(ec => ec.Course)))
            .ReverseMap()
            .ForMember(dest => dest.EnrollmentCourses, opt => opt.Ignore());
    }
}