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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            Category category = _mapper.Map<Category>(createCategoryRequest);
            Category createdCategory = await _categoryDal.AddAsync(category);
            CreatedCategoryResponse createdCategoryResponse = new CreatedCategoryResponse();
            createdCategoryResponse.Id = createdCategory.Id;
            return createdCategoryResponse;
        }

        public async Task<IPaginate<GetListedCategoryResponse>> GetListAsync()
        {
            var result = await _categoryDal.GetListAsync();
            var getListedCategoryResponse = _mapper.Map<IPaginate<GetListedCategoryResponse>>(result);
            foreach (var item in getListedCategoryResponse.Items)
            {
                _mapper.Map<Category>(item);
            }
            return getListedCategoryResponse;
        }
    }
}