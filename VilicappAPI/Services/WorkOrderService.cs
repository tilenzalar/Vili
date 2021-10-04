using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilicappAPI.Interfaces;
using VilicappAPI.Models;
using VilicappAPI.ModelsUI;

namespace VilicappAPI.Services
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly VilicAppDbContext _context;
        public WorkOrderService(VilicAppDbContext context)
        {
            _context = context;
        }

        public int AddWorkOrderRent(WorkOrderRentUI workOrderRent)
        {
            var wor = new WorkOrderRent
            {
                Company = workOrderRent.Company,
                VehicleName = workOrderRent.VehicleName,
                RentStart = workOrderRent.RentStart,
                RentEnd = workOrderRent.RentEnd,
                Note = workOrderRent.Note,
                TaxNumber = workOrderRent.TaxNumber,
                Contact = workOrderRent.Contact,
                WorkOrderStatusId = workOrderRent.WorkOrderStatusId,
                PriceTotal = workOrderRent.RentDetails.Sum(rd => rd.Price * rd.RentDays) +
                            workOrderRent.TransportationRents.Where(t => t.FixedCost.HasValue && !t.FixedCost.Value).Sum(tr => tr.Price * tr.Kilometers) +
                            workOrderRent.TransportationRents.Where(t => t.FixedCost.HasValue && t.FixedCost.Value).Sum(tr => tr.Price),
                ModifiedByUserId = workOrderRent.ModifiedByUserId,
                ModifiedTime = DateTime.Now
            };
            _context.WorkOrderRents.Add(wor);
            _context.SaveChanges();

            foreach(var rent in workOrderRent.RentDetails)
            {
                var rd = new RentDetail
                {
                    Price = rent.Price,
                    RentDays = rent.RentDays,
                    PriceTotal = rent.Price * rent.RentDays,
                    WorkOrderRentId = wor.Id
                };
                _context.RentDetails.Add(rd);
            }

            foreach (var transport in workOrderRent.TransportationRents)
            {
                var tr = new TransportationRent
                {
                    Relation = transport.Relation,
                    FixedCost = transport.FixedCost,
                    Kilometers = transport.Kilometers,
                    Price = transport.Price,
                    PriceTotal = transport.FixedCost.HasValue ? (transport.FixedCost.Value ? transport.Price : transport.Kilometers * transport.Price) : 0,
                    WorkOrderRentId = wor.Id
                };
                _context.TransportationRents.Add(tr);
            }
            _context.SaveChanges();

            return wor.Id;
        }

        public int AddWorkOrderRepair(WorkOrderRepairUI workOrderRepair)
        {
            var wor = new WorkOrderRepair
            {
                Client = workOrderRepair.Client,
                Contact = workOrderRepair.Contact,
                Description = workOrderRepair.Description,
                EndWork = workOrderRepair.EndWork,
                ForkliftName = workOrderRepair.ForkliftName,
                Note = workOrderRepair.Note,
                OrderTypeId = workOrderRepair.OrderTypeId == 0 ? null : workOrderRepair.OrderTypeId,
                Recieved = workOrderRepair.Recieved,
                TaxNumber = workOrderRepair.TaxNumber,
                WorkOrderStatusId = workOrderRepair.WorkOrderStatusId,
                PriceTotal = workOrderRepair.WorkTimeConsumptions.Sum(wtc => wtc.Price * wtc.Hours) +
                            workOrderRepair.MaterialConsumptions.Sum(mc => mc.Quantity * mc.Price) +
                            workOrderRepair.Transportations.Sum(t => t.Price * t.Kilometers),
                ModifiedByUserId = workOrderRepair.ModifiedByUserId,
                ModifiedTime = DateTime.Now
            };

            _context.WorkOrderRepairs.Add(wor);
            _context.SaveChanges();

            foreach(var wtc in workOrderRepair.WorkTimeConsumptions)
            {
                var cons = new WorkTimeConsumption
                {
                    Description = wtc.Description,
                    Hours = wtc.Hours,
                    Price = wtc.Price,
                    PriceTotal = wtc.Hours * wtc.Price,
                    WorkOrderRepairId = wor.Id,
                    WorkTimeTypeId = wtc.WorkTimeType.Id
                };
                _context.WorkTimeConsumptions.Add(cons);
            }

            foreach(var mc in workOrderRepair.MaterialConsumptions)
            {
                var material = new MaterialConsumption
                {
                    Material = mc.Material,
                    Price = mc.Price,
                    Quantity = mc.Quantity,
                    PriceTotal = mc.Price * mc.Quantity,
                    WorkOrderRepairId = wor.Id
                };
                _context.MaterialConsumptions.Add(material);
            }

            foreach(var t in workOrderRepair.Transportations)
            {
                var tran = new Transportation
                {
                    Relation = t.Relation,
                    Kilometers = t.Kilometers,
                    Price = t.Price,
                    PriceTotal = t.Kilometers * t.Price,
                    WorkOrderRepairId = wor.Id
                };
                _context.Transportations.Add(tran);
            }

            _context.SaveChanges();
            return wor.Id;
        }

        public int AddWorkOrderTransport(WorkOrderTransportUI workOrderTransport)
        {
            var wot = new WorkOrderTransport
            {
                AdditionalWorkPrice = workOrderTransport.AdditionalWorkPrice,
                AdditionalWorkQty = workOrderTransport.AdditionalWorkQty,
                AsistanceHourPrice = workOrderTransport.AsistanceHourPrice,
                AsistanceHours = workOrderTransport.AsistanceHours,
                Brand = workOrderTransport.Brand,
                Company = workOrderTransport.Company,
                Contact = workOrderTransport.Contact,
                LicenseNr = workOrderTransport.LicenseNr,
                Note = workOrderTransport.Note,
                RelationKm = workOrderTransport.RelationKm,
                RelationKmPrice = workOrderTransport.RelationKmPrice,
                RelationName = workOrderTransport.RelationName,
                TaxNumber = workOrderTransport.TaxNumber,
                ToolsQty = workOrderTransport.ToolsQty,
                ToolsQtyPrice = workOrderTransport.ToolsQtyPrice,
                VehicleTypeId = workOrderTransport.VehicleTypeId == 0 ? null : workOrderTransport.VehicleTypeId,
                WorkOrderDate = workOrderTransport.WorkOrderDate,
                WorkOrderStatusId = workOrderTransport.WorkOrderStatusId,
                PriceTotal = workOrderTransport.AdditionalWorkPrice * workOrderTransport.AdditionalWorkQty +
                            workOrderTransport.AsistanceHourPrice * workOrderTransport.AsistanceHours +
                            workOrderTransport.RelationKmPrice * workOrderTransport.RelationKm +
                            workOrderTransport.ToolsQtyPrice * workOrderTransport.ToolsQty,
                ModifiedByUserId = workOrderTransport.ModifiedByUserId,
                ModifiedTime = DateTime.Now
            };
            _context.WorkOrderTransports.Add(wot);
            _context.SaveChanges();
            return wot.Id;
        }

        public bool DeleteWorkOrder(WorkOrderOverviewUI workOrderOverview)
        {
            switch (workOrderOverview.WorkOrderType)
            {
                case "Servis":
                    var wo = _context.WorkOrderRepairs.Where(wo => wo.Id == workOrderOverview.Id).FirstOrDefault();
                    wo.Deleted = true;
                    break;
                case "Najem":
                    var wor = _context.WorkOrderRents.Where(wo => wo.Id == workOrderOverview.Id).FirstOrDefault();
                    wor.Deleted = true;
                    break;
                case "Prevoz":
                    var wot = _context.WorkOrderTransports.Where(wo => wo.Id == workOrderOverview.Id).FirstOrDefault();
                    wot.Deleted = true;
                    break;
                default:
                    return false;
            }
            _context.SaveChanges();
            return true;
        }

        public List<VehicleTypeUI> GetAllVehicleTypes()
        {
            var vehicleTypes = _context.VehicleTypes.Select(ot => new VehicleTypeUI
            {
                Id = ot.Id,
                Name = ot.Name
            }).ToList();
            return vehicleTypes;
        }

        public List<WorkOrderOverviewUI> GetAllWorkOrderOverviews()
        {
            var woRepairs = _context.WorkOrderRepairs.Where(wo => !wo.Deleted).Select(wo => new WorkOrderOverviewUI 
            {
                Id = wo.Id,
                WorkOrderType = "Servis",
                Company = wo.Client,
                DateModified = wo.ModifiedTime,
                Status = wo.WorkOrderStatus.Name,
                PriceTotal = wo.PriceTotal,
                ModifiedByUserName = wo.ModifiedByUser.Name + " " + wo.ModifiedByUser.Surname,
                WorkOrderStatusId = wo.WorkOrderStatusId
            }).ToList();

            var woRents = _context.WorkOrderRents.Where(wo => !wo.Deleted).Select(wo => new WorkOrderOverviewUI
            {
                Id = wo.Id,
                WorkOrderType = "Najem",
                Company = wo.Company,
                DateModified = wo.ModifiedTime,
                Status = wo.WorkOrderStatus.Name,
                PriceTotal = wo.PriceTotal,
                ModifiedByUserName = wo.ModifiedByUser.Name + " " + wo.ModifiedByUser.Surname,
                WorkOrderStatusId = wo.WorkOrderStatusId
            }).ToList();
            var woTransports = _context.WorkOrderTransports.Where(wo => !wo.Deleted).Select(wo => new WorkOrderOverviewUI
            {
                Id = wo.Id,
                WorkOrderType = "Prevoz",
                Company = wo.Company,
                DateModified = wo.ModifiedTime,
                Status = wo.WorkOrderStatus.Name,
                PriceTotal = wo.PriceTotal,
                ModifiedByUserName = wo.ModifiedByUser.Name + " " + wo.ModifiedByUser.Surname,
                WorkOrderStatusId = wo.WorkOrderStatusId
            }).ToList();

            woRepairs.AddRange(woRents);
            woRepairs.AddRange(woTransports);
            return woRepairs;          
        }
        public List<WorkOrderOverviewUI> GetWorkerOverviews(int workerId)
        {
            var woRepairs = _context.WorkOrderRepairs.Where(wo => !wo.Deleted && wo.ModifiedByUserId == workerId && wo.WorkOrderStatusId == 3).Select(wo => new WorkOrderOverviewUI
            {
                Id = wo.Id,
                WorkOrderType = "Servis",
                Company = wo.Client,
                DateModified = wo.ModifiedTime,
                Status = wo.WorkOrderStatus.Name,
                ModifiedByUserName = wo.ModifiedByUser.Name + " " + wo.ModifiedByUser.Surname,
                WorkOrderStatusId = wo.WorkOrderStatusId
            }).ToList();

            var woRents = _context.WorkOrderRents.Where(wo => !wo.Deleted && wo.ModifiedByUserId == workerId && wo.WorkOrderStatusId == 3).Select(wo => new WorkOrderOverviewUI
            {
                Id = wo.Id,
                WorkOrderType = "Najem",
                Company = wo.Company,
                DateModified = wo.ModifiedTime,
                Status = wo.WorkOrderStatus.Name,
                ModifiedByUserName = wo.ModifiedByUser.Name + " " + wo.ModifiedByUser.Surname,
                WorkOrderStatusId = wo.WorkOrderStatusId
            }).ToList();
            var woTransports = _context.WorkOrderTransports.Where(wo => !wo.Deleted && wo.ModifiedByUserId == workerId && wo.WorkOrderStatusId == 3).Select(wo => new WorkOrderOverviewUI
            {
                Id = wo.Id,
                WorkOrderType = "Prevoz",
                Company = wo.Company,
                DateModified = wo.ModifiedTime,
                Status = wo.WorkOrderStatus.Name,
                ModifiedByUserName = wo.ModifiedByUser.Name + " " + wo.ModifiedByUser.Surname,
                WorkOrderStatusId = wo.WorkOrderStatusId
            }).ToList();

            woRepairs.AddRange(woRents);
            woRepairs.AddRange(woTransports);
            return woRepairs;
        }

        public List<WorkOrderRentUI> GetAllWorkOrderRents()
        {
            throw new NotImplementedException();
        }

        public List<WorkOrderRepairUI> GetAllWorkOrderRepairs()
        {
            throw new NotImplementedException();
        }

        public List<WorkOrderTransportUI> GetAllWorkOrderTransports()
        {
            throw new NotImplementedException();
        }

        public List<OrderTypeUI> GetAllWorkOrderTypes()
        {
            var orderTypes = _context.OrderTypes.Select(ot => new OrderTypeUI {
                Id = ot.Id,
                Name = ot.Name
            }).ToList();
            return orderTypes;
        }

        public List<WorkTimeTypeUI> GetAllWorkTimeTypes()
        {
            var workTimeTypes = _context.WorkTimeTypes.Select(ot => new WorkTimeTypeUI
            {
                Id = ot.Id,
                Name = ot.Name
            }).ToList();
            return workTimeTypes;
        }

        public WorkOrderRentUI GetWorkOrderRent(int workOrderRentId)
        {
            var wo = _context.WorkOrderRents.Where(w => w.Id == workOrderRentId).Select(w => new WorkOrderRentUI
            {
                Id = w.Id,
                Company = w.Company,
                VehicleName = w.VehicleName,
                RentStart = w.RentStart,
                RentEnd = w.RentEnd,
                Note = w.Note,
                PriceTotal = w.PriceTotal,
                TaxNumber = w.TaxNumber,
                Contact = w.Contact
            }).FirstOrDefault();

            var rentDetails = _context.RentDetails.Where(rd => rd.WorkOrderRentId == wo.Id).Select(rd => new RentDetailUI 
            {
                RentDays = rd.RentDays,
                Price = rd.Price,
                PriceTotal = rd.PriceTotal
            }).ToList();
            wo.RentDetails = rentDetails;

            var transportationRents = _context.TransportationRents.Where(tr => tr.WorkOrderRentId == wo.Id).Select(tr => new TransportationRentUI
            { 
                Relation = tr.Relation,
                Kilometers = tr.Kilometers,
                Price = tr.Price,
                PriceTotal = tr.PriceTotal,
                FixedCost = (bool)tr.FixedCost
            }).ToList();
            wo.TransportationRents = transportationRents;
            
            return wo;
        }

        public WorkOrderRentUI GetWorkOrderRentWorker(int workOrderRentId)
        {
            var wo = _context.WorkOrderRents.Where(w => w.Id == workOrderRentId).Select(w => new WorkOrderRentUI
            {
                Id = w.Id,
                Company = w.Company,
                VehicleName = w.VehicleName,
                RentStart = w.RentStart,
                RentEnd = w.RentEnd,
                Note = w.Note,
                TaxNumber = w.TaxNumber,
                Contact = w.Contact
            }).FirstOrDefault();

            var rentDetails = _context.RentDetails.Where(rd => rd.WorkOrderRentId == wo.Id).Select(rd => new RentDetailUI
            {
                RentDays = rd.RentDays
            }).ToList();
            wo.RentDetails = rentDetails;

            var transportationRents = _context.TransportationRents.Where(tr => tr.WorkOrderRentId == wo.Id).Select(tr => new TransportationRentUI
            {
                Relation = tr.Relation,
                Kilometers = tr.Kilometers
            }).ToList();
            wo.TransportationRents = transportationRents;

            return wo;
        }

        public WorkOrderRepairUI GetWorkOrderRepair(int workOrderRepairId)
        {
            var wo = _context.WorkOrderRepairs.Where(w => w.Id == workOrderRepairId).Select(w => new WorkOrderRepairUI
            {
                Id = w.Id,
                Client = w.Client,
                Contact = w.Contact,
                ForkliftName = w.ForkliftName,
                Recieved = w.Recieved,
                EndWork = w.EndWork,
                Description = w.Description,
                Note = w.Note,
                PriceTotal = w.PriceTotal,
                TaxNumber = w.TaxNumber,
                OrderType = _context.OrderTypes.Where(ot => ot.Id == w.OrderTypeId).Select(ot => new OrderTypeUI { Id = ot.Id, Name = ot.Name }).FirstOrDefault(),
                HasAttachment = w.Attachments.Any()
            }).FirstOrDefault();
            if(wo.OrderType == null)
            {
                wo.OrderType = new OrderTypeUI();
            }

            var workTimeConsumptions = _context.WorkTimeConsumptions.Where(wtc => wtc.WorkOrderRepairId == wo.Id).Select(wtc => new WorkTimeConsumptionUI
            {
                Description = wtc.Description,
                Hours = wtc.Hours,
                PriceTotal = wtc.PriceTotal,
                Price = wtc.Price,
                WorkTimeType = _context.WorkTimeTypes.Where(wt => wt.Id == wtc.WorkTimeTypeId).Select(wt => new WorkTimeTypeUI { Id = wt.Id, Name = wt.Name }).FirstOrDefault()
            }).ToList();

            var materialConsumptions = _context.MaterialConsumptions.Where(mc => mc.WorkOrderRepairId == wo.Id).Select(mc => new MaterialConsumptionUI
            {
                Material = mc.Material,
                Quantity = mc.Quantity,
                Price = mc.Price,
                PriceTotal = mc.PriceTotal
            }).ToList();

            var transportations = _context.Transportations.Where(t => t.WorkOrderRepairId == wo.Id).Select(t => new TransportationUI
            {
                Relation = t.Relation,
                Kilometers = t.Kilometers,
                Price = t.Price,
                PriceTotal = t.PriceTotal
            }).ToList();

            wo.WorkTimeConsumptions = workTimeConsumptions;
            wo.MaterialConsumptions = materialConsumptions;
            wo.Transportations = transportations;
            return wo;
        }

        public WorkOrderRepairUI GetWorkOrderRepairWorker(int workOrderRepairId)
        {
            var wo = _context.WorkOrderRepairs.Where(w => w.Id == workOrderRepairId).Select(w => new WorkOrderRepairUI
            {
                Id = w.Id,
                Client = w.Client,
                Contact = w.Contact,
                ForkliftName = w.ForkliftName,
                Recieved = w.Recieved,
                EndWork = w.EndWork,
                Description = w.Description,
                Note = w.Note,
                TaxNumber = w.TaxNumber,
                OrderType = _context.OrderTypes.Where(ot => ot.Id == w.OrderTypeId).Select(ot => new OrderTypeUI { Id = ot.Id, Name = ot.Name }).FirstOrDefault()
            }).FirstOrDefault();
            if (wo.OrderType == null)
            {
                wo.OrderType = new OrderTypeUI();
            }

            var workTimeConsumptions = _context.WorkTimeConsumptions.Where(wtc => wtc.WorkOrderRepairId == wo.Id).Select(wtc => new WorkTimeConsumptionUI
            {
                Description = wtc.Description,
                Hours = wtc.Hours,
                WorkTimeType = _context.WorkTimeTypes.Where(wt => wt.Id == wtc.WorkTimeTypeId).Select(wt => new WorkTimeTypeUI { Id = wt.Id, Name = wt.Name }).FirstOrDefault()
            }).ToList();

            var materialConsumptions = _context.MaterialConsumptions.Where(mc => mc.WorkOrderRepairId == wo.Id).Select(mc => new MaterialConsumptionUI
            {
                Material = mc.Material,
                Quantity = mc.Quantity
            }).ToList();

            var transportations = _context.Transportations.Where(t => t.WorkOrderRepairId == wo.Id).Select(t => new TransportationUI
            {
                Relation = t.Relation,
                Kilometers = t.Kilometers
            }).ToList();

            wo.WorkTimeConsumptions = workTimeConsumptions;
            wo.MaterialConsumptions = materialConsumptions;
            wo.Transportations = transportations;
            return wo;
        }
        public WorkOrderTransportUI GetWorkOrderTransport(int workOrderTransportId)
        {
            var wo = _context.WorkOrderTransports.Where(wot => wot.Id == workOrderTransportId).Select(wot => new WorkOrderTransportUI
            {
                Id = wot.Id,
                Company = wot.Company,
                Brand = wot.Brand,
                LicenseNr = wot.LicenseNr,
                WorkOrderDate = wot.WorkOrderDate,
                RelationName = wot.RelationName,
                RelationKm = wot.RelationKm,
                RelationKmPrice = wot.RelationKmPrice,
                ToolsQty = wot.ToolsQty,
                ToolsQtyPrice = wot.ToolsQtyPrice,
                AdditionalWorkQty = wot.AdditionalWorkQty,
                AdditionalWorkPrice = wot.AdditionalWorkPrice,
                AsistanceHours = wot.AsistanceHours,
                AsistanceHourPrice = wot.AsistanceHourPrice,
                Note = wot.Note,
                PriceTotal = wot.PriceTotal,
                TaxNumber = wot.TaxNumber,
                Contact = wot.Contact,
                vehicleType = _context.VehicleTypes.Where(wt => wt.Id == wot.VehicleTypeId).Select(wt => new VehicleTypeUI { Id = wt.Id, Name = wt.Name }).FirstOrDefault()
            }).FirstOrDefault();
            if (wo.vehicleType == null)
            {
                wo.vehicleType = new VehicleTypeUI();
            }

            return wo;
        }
        public WorkOrderTransportUI GetWorkOrderTransportWorker(int workOrderTransportId)
        {
            var wo = _context.WorkOrderTransports.Where(wot => wot.Id == workOrderTransportId).Select(wot => new WorkOrderTransportUI
            {
                Id = wot.Id,
                Company = wot.Company,
                Brand = wot.Brand,
                LicenseNr = wot.LicenseNr,
                WorkOrderDate = wot.WorkOrderDate,
                RelationName = wot.RelationName,
                RelationKm = wot.RelationKm,
                ToolsQty = wot.ToolsQty,
                AdditionalWorkQty = wot.AdditionalWorkQty,
                AsistanceHours = wot.AsistanceHours,
                Note = wot.Note,
                TaxNumber = wot.TaxNumber,
                Contact = wot.Contact,
                vehicleType = _context.VehicleTypes.Where(wt => wt.Id == wot.VehicleTypeId).Select(wt => new VehicleTypeUI { Id = wt.Id, Name = wt.Name }).FirstOrDefault()
            }).FirstOrDefault();
            if (wo.vehicleType == null)
            {
                wo.vehicleType = new VehicleTypeUI();
            }

            return wo;
        }

        public bool AddAttachment(AttachmentUI attachment)
        {
            var att = new Attachment
            {
                WorkOrderRepairId = attachment.WorkOrderRepairId,
                Name = attachment.Name,
                BinaryData = attachment.BinaryData
            };
            _context.Attachments.Add(att);
            _context.SaveChanges();
            return true;
        }

        public AttachmentUI GetAttachment(int workOrderRepairId)
        {
            var att = _context.Attachments.Where(a => a.WorkOrderRepairId == workOrderRepairId).Select(a => new AttachmentUI
            {
                Id = a.Id,
                Name = a.Name,
                BinaryData = a.BinaryData,
                WorkOrderRepairId = a.WorkOrderRepairId
            }).FirstOrDefault();

            return att;
        }

        public bool DeleteAttachemnt(int attachmentId)
        {
            var att = _context.Attachments.Where(a => a.Id == attachmentId).FirstOrDefault();
            _context.Attachments.Remove(att);
            _context.SaveChanges();
            return true;
        }

        public bool AddImages(List<ImageUI> images)
        {
            foreach(var img in images)
            {
                var dbimg = new Image
                {
                    Name = img.Name,
                    WorkOrderRepairId = img.WorkOrderRepairId,
                    BinaryData = img.BinaryData
                };
                _context.Images.Add(dbimg);
            }
            _context.SaveChanges();
            return true;
        }

        public bool DeleteImages(int workOrderRepairId)
        {
            var images = _context.Images.Where(i => i.WorkOrderRepairId == workOrderRepairId);
            _context.Images.RemoveRange(images);
            _context.SaveChanges();
            return true;
        }

        public List<ImageUI> GetImages(int workOrderRepairId)
        {
            var images = _context.Images.Where(i => i.WorkOrderRepairId == workOrderRepairId).Select(i => new ImageUI
            {
                Id = i.Id,
                BinaryData = i.BinaryData,
                Name = i.Name,
                WorkOrderRepairId = i.WorkOrderRepairId
            }).ToList();
            return images;
        }
    }
}
