using DemoUnitOrWork.Interfaces;
using DemoUnitOrWork.Models;
using DemoUnitOrWork.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoUnitOrWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork unitOfWork;

        public BrandController(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandRepository.GetListAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
                return NotFound();
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            await _brandRepository.AddAsync(brand);
            await unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Brand brand)
        {
            if (id != brand.Id)
                return BadRequest();

            await _brandRepository.UpdateAsync(brand);
            await unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _brandRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }

}
