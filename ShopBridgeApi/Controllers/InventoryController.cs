using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBridgeApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridgeApi.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public InventoryController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _dataAccessProvider.GetInentoryRecords();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await _dataAccessProvider.GetInventorySingleRecord(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inventory inventory)
        {
            
            InventoryValidator validationRules = new InventoryValidator();
            inventory.createdOn = DateTime.Now;
            inventory.updatedOn = DateTime.Now;
            return await _dataAccessProvider.AddInventoryRecord(inventory);
        }

        // PUT api/values/5
        [HttpPut]
        public  IActionResult Put([FromBody] Inventory inventory)
        {
            inventory.updatedOn = DateTime.Now;
            return _dataAccessProvider.UpdateInventoryRecord(inventory);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _dataAccessProvider.DeleteInventoryRecord(id);
        }
    }
}
