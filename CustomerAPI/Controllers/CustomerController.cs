using AutoMapper;
using CustomerAPI.Data;
using CustomerAPI.Dtos;
using CustomerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _customerRepository.GetAllAsync();
            var results = _mapper.Map<List<CustomerReadDto>>(list);
            var _results = JsonConvert.DeserializeObject<List<CustomerReadDto>>(JsonConvert.SerializeObject(list));
            return Ok(results);

        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var customer = _customerRepository.GetAsync(id);
            var results = JsonConvert.DeserializeObject<CustomerReadDto>(JsonConvert.SerializeObject(customer));
            var _results = _mapper.Map<CustomerReadDto>(customer);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] CustomerCreateDto obj)
        {
            //var customer = JsonConvert.DeserializeObject<Customer>(JsonConvert.SerializeObject(obj));
            //await _customerRepository.AddAsync(customer);
            //await _customerRepository.SaveAsync();

            var customerToInsert = _mapper.Map<Customer>(obj);
            await _customerRepository.AddAsync(customerToInsert);
            await _customerRepository.SaveAsync();
            return CreatedAtAction("Get",
            new { id = customerToInsert.Id }, customerToInsert);


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpadateCustomer(int id, [FromBody] CustomerUpdateDto obj)
        {
            if (id != obj.Id) return BadRequest();
            var customer = _mapper.Map<Customer>(obj);
            await _customerRepository.UpdateAsync(customer);
            await _customerRepository.SaveAsync();
            return NoContent();
        }

        public async Task<IActionResult> DeleteCustome(int id)
        {
            await _customerRepository.DeleteAsync(id);
            await _customerRepository.SaveAsync();
            return NoContent();

        }
    }
}
