using Delivery.Management.MVC.Contracts;
using Delivery.Management.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Management.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DeliveryAllocationsController : Controller
    {
        private readonly IDeliveryAllocationService _deliveryAllocationRepository;

        public DeliveryAllocationsController(IDeliveryAllocationService deliveryAllocationRepository)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
        }

        // GET: DeliveryAllocationsController
        public async Task<ActionResult> Index()
        {
            var model = await _deliveryAllocationRepository.GetDeliveryAllocations();
            return View(model);
        }

        // GET: DeliveryAllocationsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _deliveryAllocationRepository.GetDeliveryAllocationDetails(id);
            return View(model);
        }

        // GET: DeliveryAllocationsController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: DeliveryAllocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDeliveryAllocationVM deliveryAllocation)
        {
            try
            {
                var response = await _deliveryAllocationRepository.CreateDeliveryAllocation(deliveryAllocation);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(deliveryAllocation);
        }

        // GET: DeliveryAllocationsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _deliveryAllocationRepository.GetDeliveryAllocationDetails(id);
            return View(model);
        }

        // POST: DeliveryAllocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DeliveryAllocationVM deliveryAllocation)
        {
            try
            {
                var response = await _deliveryAllocationRepository.UpdateDeliveryAllocation(id, deliveryAllocation);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(deliveryAllocation);
        }

        // POST: DeliveryAllocationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _deliveryAllocationRepository.DeleteDeliveryAllocation(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
    }
}
