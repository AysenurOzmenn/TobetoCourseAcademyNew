using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        private ICourseDal _courseDal;
        private IMapper _mapper;
        public CourseManager(ICourseDal courseDal, IMapper mapper)
        {
            _courseDal = courseDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
        {
            //Course course = new Course();
            //course.Id = Guid.NewGuid();
            //course.Name = createCourseRequest.Name;
            //course.Description = createCourseRequest.Description;
            //course.Price = createCourseRequest.Price;

            //Course createdCourse = await _courseDal.AddAsync(course);
            //CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
            //createdCourseResponse.Id = createdCourse.Id;
            //createdCourseResponse.Name = createCourseRequest.Name;
            //createdCourseResponse.Description = createCourseRequest.Description;
            //createdCourseResponse.Price = createCourseRequest.Price;
            //return createdCourseResponse;

            Course course = _mapper.Map<Course>(createCourseRequest);
            Course createdCourse = await _courseDal.AddAsync(course);
            CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
            createdCourseResponse.Id = createdCourse.Id;
            return createdCourseResponse;
        }

        public async Task<IPaginate<GetListedCourseResponse>> GetListAsync()
        {
            //var result = await _courseDal.GetListAsync();
            //List<GetListedCourseResponse> getList = new List<GetListedCourseResponse>();

            //foreach (var item in result.Items)
            //{
            //    GetListedCourseResponse getListedCourseResponse = new GetListedCourseResponse();
            //    getListedCourseResponse.Id = item.Id;
            //    getListedCourseResponse.Name = item.Name;
            //    getListedCourseResponse.Description = item.Description;
            //    getListedCourseResponse.Price = item.Price;
            //    getList.Add(getListedCourseResponse);
            //}
            //Paginate<GetListedCourseResponse> _paginate = new Paginate<GetListedCourseResponse>();
            //_paginate.Pages = result.Pages;
            //_paginate.Items = getList;
            //_paginate.Index = result.Index;
            //_paginate.Size = result.Size;
            //_paginate.Count = result.Count;
            //_paginate.From = result.From;
            ////_paginate.HasNext=result.Result.HasNext; //auto value
            ////_paginate.HasPrevious = result.Result.HasPrevious; //auto value
            //return _paginate;

            var result = await _courseDal.GetListAsync();
            var getListedCourseResponse = _mapper.Map<IPaginate<GetListedCourseResponse>>(result);

            foreach (var item in getListedCourseResponse.Items)
            {
                _mapper.Map<Course>(item);
            }
            return getListedCourseResponse;

        }
    }
}

    
