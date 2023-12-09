using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private IInstructorDal _instructorDal;
        private IMapper _mapper;

        public InstructorManager(IInstructorDal instructorDal, IMapper mapper)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
        }

        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
            Instructor createdInstructor = await _instructorDal.AddAsync(instructor);
            CreatedInstructorResponse createdInstructorResponse = new CreatedInstructorResponse();
            createdInstructorResponse.Id = createdInstructor.Id;
            return createdInstructorResponse;
        }

        public async Task<IPaginate<GetListedInstructorResponse>> GetListAsync()
        {
            var result = await _instructorDal.GetListAsync();
            var getListedInstructorResponse = _mapper.Map<IPaginate<GetListedInstructorResponse>>(result);
            foreach (var item in getListedInstructorResponse.Items)
            {
                _mapper.Map<Instructor>(item);
            }
            return getListedInstructorResponse;
        }
    }
}
