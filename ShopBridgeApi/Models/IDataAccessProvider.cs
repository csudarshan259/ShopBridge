using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShopBridgeApi.Models
{
    public interface IDataAccessProvider
    {
        Task<IActionResult> AddInventoryRecord(Inventory inventory);
        IActionResult UpdateInventoryRecord(Inventory inventory);
        Task<IActionResult> DeleteInventoryRecord(int id);
        Task<IActionResult> GetInventorySingleRecord(int id);
        Task<IActionResult> GetInentoryRecords();
    }
}
