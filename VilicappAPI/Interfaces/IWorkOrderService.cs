using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilicappAPI.Models;
using VilicappAPI.ModelsUI;

namespace VilicappAPI.Interfaces
{
    public interface IWorkOrderService
    {
        int AddWorkOrderRepair(WorkOrderRepairUI workOrderRepair);
        int AddWorkOrderRent(WorkOrderRentUI workOrderRent);
        int AddWorkOrderTransport(WorkOrderTransportUI workOrderTransport);
        bool DeleteWorkOrder(WorkOrderOverviewUI workOrderOverview);
        bool AddAttachment(AttachmentUI attachment);
        bool DeleteAttachemnt(int attachmentId);
        bool AddImages(List<ImageUI> images);
        bool DeleteImages(int workOrderRepairId);
        List<ImageUI> GetImages(int workOrderRepairId);
        WorkOrderRentUI GetWorkOrderRent(int workOrderRentId);
        WorkOrderRentUI GetWorkOrderRentWorker(int workOrderRentId);
        WorkOrderRepairUI GetWorkOrderRepair(int workOrderRepairId);
        WorkOrderRepairUI GetWorkOrderRepairWorker(int workOrderRepairId);
        WorkOrderTransportUI GetWorkOrderTransport(int workOrderTransportId);
        WorkOrderTransportUI GetWorkOrderTransportWorker(int workOrderTransportId);
        List<WorkOrderOverviewUI> GetAllWorkOrderOverviews();
        List<WorkOrderOverviewUI> GetWorkerOverviews(int workerId);
        List<WorkOrderRepairUI> GetAllWorkOrderRepairs();
        List<WorkOrderRentUI> GetAllWorkOrderRents();
        List<WorkOrderTransportUI> GetAllWorkOrderTransports();
        List<OrderTypeUI> GetAllWorkOrderTypes();
        List<WorkTimeTypeUI> GetAllWorkTimeTypes();
        List<VehicleTypeUI> GetAllVehicleTypes();
        AttachmentUI GetAttachment(int workOrderRepairId);
    }
}
