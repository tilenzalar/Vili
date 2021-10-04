using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilicappAPI.Interfaces;
using VilicappAPI.Models;
using VilicappAPI.ModelsUI;

namespace VilicappAPI.Controllers
{
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(VilicAppDbContext context, IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpPost("AddWorkOrderRepair")]
        public ActionResult<int> AddWorkOrderRepair([FromBody] WorkOrderRepairUI workOrderRepair)
        {
            return _workOrderService.AddWorkOrderRepair(workOrderRepair);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpPost("AddWorkOrderRent")]
        public ActionResult<int> AddWorkOrderRent([FromBody] WorkOrderRentUI workOrderRent)
        {
            return _workOrderService.AddWorkOrderRent(workOrderRent);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpPost("AddAttachment")]
        public ActionResult<bool> AddAttachment([FromBody] AttachmentUI attachment)
        {
            return _workOrderService.AddAttachment(attachment);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpDelete("DeleteAttachemnt")]
        public ActionResult<bool> DeleteAttachemnt(int attachmentId)
        {
            return _workOrderService.DeleteAttachemnt(attachmentId);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpPost("AddWorkOrderTransport")]
        public ActionResult<int> AddWorkOrderTransport([FromBody] WorkOrderTransportUI workOrderTransport)
        {
            return _workOrderService.AddWorkOrderTransport(workOrderTransport);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetAttachment")]
        public ActionResult<AttachmentUI> GetAttachment(int workOrderRepairId)
        {
            return _workOrderService.GetAttachment(workOrderRepairId);
        }      

        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetAllWorkOrderTypes")]
        public ActionResult<List<OrderTypeUI>> GetAllWorkOrderTypes()
        {
            return _workOrderService.GetAllWorkOrderTypes();
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetAllWorkTimeTypes")]
        public ActionResult<List<WorkTimeTypeUI>> GetAllWorkTimeTypes()
        {
            return _workOrderService.GetAllWorkTimeTypes();
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetAllVehicleTypes")]
        public ActionResult<List<VehicleTypeUI>> GetAllVehicleTypes()
        {
            return _workOrderService.GetAllVehicleTypes();
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpGet("GetAllWorkOrderOverviews")]
        public ActionResult<List<WorkOrderOverviewUI>> GetAllWorkOrderOverviews()
        {
            return _workOrderService.GetAllWorkOrderOverviews();
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpDelete("DeleteWorkOrder")]
        public ActionResult<bool> DeleteWorkOrder([FromBody] WorkOrderOverviewUI workOrderOverview)
        {
            return _workOrderService.DeleteWorkOrder(workOrderOverview);
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpGet("GetWorkOrderRent")]
        public ActionResult<WorkOrderRentUI> GetWorkOrderRent(int workOrderRentId)
        {
            return _workOrderService.GetWorkOrderRent(workOrderRentId);
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpGet("GetWorkOrderRepair")]
        public ActionResult<WorkOrderRepairUI> GetWorkOrderRepair(int workOrderRepairId)
        {
            return _workOrderService.GetWorkOrderRepair(workOrderRepairId);
        }
        [NeedsOneOfPermissions("Admin")]
        [HttpGet("GetWorkOrderTransport")]
        public ActionResult<WorkOrderTransportUI> GetWorkOrderTransport(int workOrderTransportId)
        {
            return _workOrderService.GetWorkOrderTransport(workOrderTransportId);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetWorkOrderRentWorker")]
        public ActionResult<WorkOrderRentUI> GetWorkOrderRentWorker(int workOrderRentId)
        {
            return _workOrderService.GetWorkOrderRentWorker(workOrderRentId);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetWorkOrderRepairWorker")]
        public ActionResult<WorkOrderRepairUI> GetWorkOrderRepairWorker(int workOrderRepairId)
        {
            return _workOrderService.GetWorkOrderRepairWorker(workOrderRepairId);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetWorkOrderTransportWorker")]
        public ActionResult<WorkOrderTransportUI> GetWorkOrderTransportWorker(int workOrderTransportId)
        {
            return _workOrderService.GetWorkOrderTransportWorker(workOrderTransportId);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetWorkerOverviews")]
        public ActionResult<List<WorkOrderOverviewUI>> GetWorkerOverviews(int workerId)
        {
            return _workOrderService.GetWorkerOverviews(workerId);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpPost("AddImages")]
        public ActionResult<bool> AddImages([FromBody] List<ImageUI> images)
        {
            return _workOrderService.AddImages(images);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpDelete("DeleteImages")]
        public ActionResult<bool> DeleteImages(int workOrderRepairId)
        {
            return _workOrderService.DeleteImages(workOrderRepairId);
        }
        [NeedsOneOfPermissions("Admin", "Worker")]
        [HttpGet("GetImages")]
        public ActionResult<List<ImageUI>> GetImages(int workOrderRepairId)
        {
            return _workOrderService.GetImages(workOrderRepairId);
        }
    }
}
