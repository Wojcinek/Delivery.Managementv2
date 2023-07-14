using Delivery.Management.MVC.Contracts;
using Delivery.Management.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Management.MVC.Controllers
{
    public class DeliveryTypesController : Controller
    {
        private readonly IDeliveryTypeService _deliveryTypeRepository;

        public DeliveryTypesController(IDeliveryTypeService deliveryTypeRepository)
        {
            _deliveryTypeRepository = deliveryTypeRepository;
        }

        // GET: DeliveryTypesController
        public async Task<ActionResult> Index()
        {
            var model = await _deliveryTypeRepository.GetDeliveryTypes();
            return View(model);
        }

        // GET: DeliveryTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _deliveryTypeRepository.GetDeliveryTypesDetails(id);
            return View(model);
        }

        // GET: DeliveryTypesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: DeliveryTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDeliveryTypeVM deliveryType)
        {
            try
            {
                var response = await _deliveryTypeRepository.CreateDeliveryType(deliveryType);
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
            return View(deliveryType);
        }

        // GET: DeliveryTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _deliveryTypeRepository.GetDeliveryTypesDetails(id);
            return View(model);
        }

        // POST: DeliveryTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DeliveryTypeVM deliveryType)
        {
            try
            {
                var response = await _deliveryTypeRepository.UpdateDeliveryType(id, deliveryType);
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
            return View(deliveryType);
        }

        // GET: DeliveryTypesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _deliveryTypeRepository.DeleteDeliveryType(id);
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
