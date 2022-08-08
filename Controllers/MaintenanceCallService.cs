using bulk_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using bulk_ops.Controllers;

namespace bulk_ops.BusinessLogic
{
  public class MaintenanceCallService
  {
    private readonly AppDbContext _appDbContext;
    private DateTime Start;
    private TimeSpan TimeSpan;
    //The "duration" variable contains Execution time when we doing the operations (Insert,Update,Delete)  
    public MaintenanceCallService(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public async Task<TimeSpan> AddBulkDataAsync()
    {
      List<MaintenanceCall> maintenanceCalls = new(); // C# 9 Syntax.  
      Start = DateTime.Now;
      for (int i = 0; i < 100000; i++)
      {
        maintenanceCalls.Add(new MaintenanceCall()
        {
          Year = "Year" + i,
          Cycle = "Cycle" + i,
          StartDate = "StartDate" + i,
          EndDate = "EndDate" + i
        });
      }
      await _appDbContext.BulkInsertAsync(maintenanceCalls);
      TimeSpan = DateTime.Now - Start;
      return TimeSpan;
    }

    public async Task<TimeSpan> UpdateBulkDataAsync()
    {
      List<MaintenanceCall> maintenanceCalls = new(); // C# 9 Syntax.  
      Start = DateTime.Now;
      for (int i = 0; i < 100000; i++)
      {
        maintenanceCalls.Add(new MaintenanceCall()
        {
          Year = "Year" + i,
          Cycle = "Cycle" + i,
          StartDate = "StartDate" + i,
          EndDate = "EndDate" + i
        });
      }
      await _appDbContext.BulkUpdateAsync(maintenanceCalls);
      TimeSpan = DateTime.Now - Start;
      return TimeSpan;
    }

    public async Task<TimeSpan> DeleteBulkDataAsync()
    {
      List<MaintenanceCall> maintenanceCalls = new(); // C# 9 Syntax.  
      Start = DateTime.Now;
      maintenanceCalls = _appDbContext.MaintenanceCall.ToList();
      await _appDbContext.BulkDeleteAsync(maintenanceCalls);
      TimeSpan = DateTime.Now - Start;
      return TimeSpan;
    }
  }
}
