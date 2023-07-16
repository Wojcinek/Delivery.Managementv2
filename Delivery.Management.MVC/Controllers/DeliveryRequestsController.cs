using System.Data;
using Delivery.Management.MVC.Contracts;
using Delivery.Management.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Delivery.Management.MVC.Controllers
{
    public class DeliveryRequestsController : Controller
    {
        private readonly IDeliveryRequestService _deliveryRequestRepository;
        private readonly IDeliveryAllocationService _deliveryAllocationRepository;
        private readonly IDeliveryTypeService _deliveryTypeRepository;

        public DeliveryRequestsController(IDeliveryRequestService deliveryRequestRepository, IDeliveryAllocationService deliveryAllocationRepository, IDeliveryTypeService deliveryTypeRepository)
        {
            _deliveryRequestRepository = deliveryRequestRepository;
            _deliveryTypeRepository = deliveryTypeRepository;
            _deliveryAllocationRepository = deliveryAllocationRepository;

        }

        // GET: DeliveryRequestsController
        public async Task<ActionResult> Index()
        {
            var model = await _deliveryRequestRepository.GetDeliveryRequests();
            return View(model);
        }

        // GET: DeliveryRequestsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _deliveryRequestRepository.GetDeliveryRequestsDetails(id);
            return View(model);
        }

        // GET: DeliveryRequestsController/Create
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: DeliveryRequestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Create(CreateDeliveryRequestVM deliveryRequest)
        {
            try
            {
                var response = await _deliveryRequestRepository.CreateDeliveryRequest(deliveryRequest);
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
            return View(deliveryRequest);
        }

        // GET: DeliveryRequestsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _deliveryRequestRepository.GetDeliveryRequestsDetails(id);
            return View(model);
        }

        // POST: DeliveryRequestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DeliveryRequestVM deliveryRequest)
        {
            try
            {
                var response = await _deliveryRequestRepository.UpdateDeliveryRequest(id, deliveryRequest);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(deliveryRequest);
        }


        //POST: DeliveryRequestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _deliveryRequestRepository.DeleteDeliveryRequest(id);
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
