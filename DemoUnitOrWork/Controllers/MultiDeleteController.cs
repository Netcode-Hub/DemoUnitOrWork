using DemoUnitOrWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace DemoUnitOfWorkPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiDeleteController(
        IProductRepository product,
        ICategoryRepository category,
        IBrandRepository brand, IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItems(int id)
        {
            await product.DeleteAsync(id);
            await category.DeleteAsync(id);
            await brand.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
