using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Persistence yi referans olarak ekledim, Persistence de Application layer ı referans ediyor dolayısıyla bunu dolaylı yoldan referansı çağırabiliyorum.
        //private readonly IProductService _productService;

        //Referansı construction dan injecte edelim
        //public ProductsController(IProductService productService)
        //{
        //Artık IoC konteynerda IProductService interface referansına karşılık bana Persistence daki Concretes sınıfın nesnesi gelecektir. Gelen nesneyi de gönül rahatlığıyla  public IActionResult GetProducts() ta kullanabilirim
        //  _productService = productService;
        //}
        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    var products = _productService.GetProducts();
        //  return Ok(products);
        //}

        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository) //Çok fazla injection yaptığımızda injection hell hatası alırız. Bu yüzden proxy üzerinden ilerleriz
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }



        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock =10},
                new(){Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock =20},
                new(){Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDate = DateTime.UtcNow, Stock =130},
            });
            await _productWriteRepository.SaveAsync();

        }
    }
}
