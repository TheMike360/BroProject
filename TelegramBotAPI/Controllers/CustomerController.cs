using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TelegramBotAPI.Data;
using TelegramBotAPI.Entity;
using TelegramBotAPI.Controllers;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMongoCollection<Customer> _customer;
        public CustomerController(MongoDbService mongoDbService)
        {
            _customer = mongoDbService.Database?.GetCollection<Customer>("customer");
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customer.Find(FilterDefinition<Customer>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer?>> GetById(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
            var customer = _customer.Find(filter).FirstOrDefault();
            return customer is not null ? Ok(customer) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            await _customer.InsertOneAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, customer.Id);
            var update = Builders<Customer>.Update
                .Set(x => x.CustomerName, customer.CustomerName)
                .Set(x => x.PhoneNumber, customer.PhoneNumber)
                .Set(x => x.Language, customer.Language)
                .Set(x => x.Signed, customer.Signed)
                .Set(x => x.RegistrationDate, customer.RegistrationDate);
            await _customer.UpdateOneAsync(filter, update);

            return Ok();
        }
    }
}
