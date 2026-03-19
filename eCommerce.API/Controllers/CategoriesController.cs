using AutoMapper;
using eCommerce.Business.Abstracts;
using eCommerce.DTO.DTOs.CategoryDTOs;
using eCommerce.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _service.GetListBL();
            var mapping = _mapper.Map<List<ResultCategoryDTO>>(values);
            return Ok(mapping);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _service.GetByIdAsyncBL(id);
            var mapping = _mapper.Map<ResultCategoryDTO>(value);
            return Ok(mapping);
        }

        [HttpGet("notracking")]
        public async Task<IActionResult> GetListNoTracking()
        {
            var values = await _service.GetListNoTrackingAsyncBL();
            var mapping = _mapper.Map<List<ResultCategoryDTO>>(values);
            return Ok(mapping);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int page, int pageSize)
        {
            var values = await _service.GetPagedAsyncBL(page, pageSize);
            var mapping = _mapper.Map<List<ResultCategoryDTO>>(values);
            return Ok(mapping);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetListByFilter(string name)
        {
            var values = await _service.GetListByFilterAsyncBL(x => x.CategoryName.Contains(name));
            var mapping = _mapper.Map<List<ResultCategoryDTO>>(values);
            return Ok(mapping);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCategoryDTO dto)
        {
            var mapping = _mapper.Map<Category>(dto);
            await _service.InsertAsyncBL(mapping);
            return Ok("Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDTO dto)
        {
            var mapping = _mapper.Map<Category>(dto);
            await _service.UpdateAsyncBL(mapping);
            return Ok("Başarıyla Gncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteWithProductsAsync(id);
            return Ok("Başarıyla Silindi");
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCount()
            => Ok(await _service.GetCountAsyncBL());
    }
}
