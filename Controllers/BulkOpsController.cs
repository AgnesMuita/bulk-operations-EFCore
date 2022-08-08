using bulk_ops.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bulk_ops.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BulkOperationsController : ControllerBase
  {
    private readonly MaintenanceCallService _maintenanceCallService;
    public BulkOperationsController(MaintenanceCallService maintenanceCallService)
    {
      _maintenanceCallService = maintenanceCallService;
    }
    [HttpPost(nameof(AddBulkData))]
    public async Task<IActionResult> AddBulkData()
    {
      var response = await _maintenanceCallService.AddBulkDataAsync();
      return Ok(response);
    }
    [HttpPut(nameof(UpdateBulkData))]
    public async Task<IActionResult> UpdateBulkData()
    {
      var response = await _maintenanceCallService.UpdateBulkDataAsync();
      return Ok(response);
    }
    [HttpDelete(nameof(DeleteBulkData))]
    public async Task<IActionResult> DeleteBulkData()
    {
      var response = await _maintenanceCallService.DeleteBulkDataAsync();
      return Ok(response);
    }
  }
}