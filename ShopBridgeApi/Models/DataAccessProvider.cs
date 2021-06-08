using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShopBridgeApi.Models
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly InventoryDbContext _inventoryDbContext;
        public DataAccessProvider(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<IActionResult> AddInventoryRecord(Inventory inventory)
        {
            try
            {
                await _inventoryDbContext.AddAsync(inventory);
                _inventoryDbContext.SaveChanges();
                return new OkObjectResult("Inventory Added Successfully");


            }catch(Exception ex)
            {
                return new ContentResult
                {
                    Content = ex.ToString(),
                    ContentType = "application/json",
                    StatusCode = 500
                };



            }

        }

        public async Task< IActionResult> DeleteInventoryRecord(int id)
        {
            try
            {
                var entity = await _inventoryDbContext.Inventory.FirstOrDefaultAsync(x=>x.id==id);
                
                _inventoryDbContext.Remove(entity);
                _inventoryDbContext.SaveChanges();
                return new OkObjectResult("Inventory Deleted Successfully");


            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    Content = ex.ToString(),
                    ContentType = "application/json",
                    StatusCode = 500
                };
            }
        }

        public async Task<IActionResult> GetInentoryRecords()
        {
            try
            {

                var inventories = await _inventoryDbContext.Inventory.ToListAsync();

                return new OkObjectResult(inventories);


            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    Content = ex.ToString(),
                    ContentType = "application/json",
                    StatusCode = 500
                };
            }
        }

        public async Task<IActionResult> GetInventorySingleRecord(int id)
        {
            var entity = await _inventoryDbContext.Inventory.FirstOrDefaultAsync(x => x.id == id);
            return new OkObjectResult( entity);
        }

        public   IActionResult UpdateInventoryRecord(Inventory inventory)
        {
            try
            {
                 _inventoryDbContext.Update(inventory);
                _inventoryDbContext.SaveChanges();
                return new OkObjectResult("Inventory Updated Successfully");


            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    Content = ex.ToString(),
                    ContentType = "application/json",
                    StatusCode = 500
                };
            }
        }
    }
}
