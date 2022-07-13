using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CRUDWebAPI.Authorization;
using CRUDWebAPI.Helpers;
using CRUDWebAPI.Models.Products;
using CRUDWebAPI.Services;

namespace CRUDWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductsService _productsService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ProductsController(
            IProductsService productsService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _productsService = productsService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(ProductRequest model)
        {
            _productsService.Register(model);
            return Ok(new { message = "Registration successful" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _productsService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _productsService.GetById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProductRequest model)
        {
            _productsService.Update(id, model);
            return Ok(new { message = "Product updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productsService.Delete(id);
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
