using Delivery.Management.MVC.Contracts;
using Delivery.Management.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Management.MVC.Controllers
{
    public class DeliveryRequestsController : Controller
    {
        private readonly IDeliveryRequestService _deliveryRequestRepository;

        public DeliveryRequestsController(IDeliveryRequestService deliveryRequestRepository)
        {
            _deliveryRequestRepository = deliveryRequestRepository;
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
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: DeliveryRequestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: DeliveryRequestsController/Delete/5
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var model = await _deliveryRequestRepository.DeleteDeliveryRequest(id);
        //    return View();
        //}

        // POST: DeliveryRequestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
