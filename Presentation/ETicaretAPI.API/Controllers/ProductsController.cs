using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new () { Id = customerId, Name= "Selami"});
            //await _orderWriteRepository.AddAsync(new() { Description = "lorem ipsum dolor", Address = "Çankaya", CustomerId = customerId });
            //await _orderWriteRepository.AddAsync(new() { Description = "lorem ipsum", Address = "Kızlay", CustomerId = customerId });
            //await _orderWriteRepository.SaveAsync();
            Order order = await _orderReadRepository.GetByIdAsync("b7d93058-203d-4082-b6fd-ad2925cc9413");
            order.Address = "Istanbul";
            await _orderWriteRepository.SaveAsync();
            
        }
    }
}
