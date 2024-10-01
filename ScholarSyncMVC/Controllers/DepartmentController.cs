using Microsoft.AspNetCore.Mvc;
using ScholarSyncMVC.Models;
using ScholarSyncMVC.Repository.Contract;
using ScholarSyncMVC.ViewModels;

namespace ScholarSyncMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository<Department> _department;

        public DepartmentController(IGenericRepository<Department> department)
        {
            _department = department;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _department.GetAll();
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }


        public async Task<IActionResult> Details(int id)
        {
            var item = await _department.GetAsync(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _department.Add(department);
                    var count = _department.Complet();
                    if (count > 0)
                    {
                        ViewData["Message"] = "Department Created Successfully";
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException?.Message ?? ex.Message);
                }
            }
            return View(department);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _department.Update(department);
                    var count = _department.Complet();
                    if (count > 0)
                    {
                        ViewData["Message"] = "Department Updated Successfully";
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException?.Message ?? ex.Message);

                }

            }
            return View(department);

        }
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Department department)
        {
            try
            {
                department.IsDeleted = true; // Assuming you have a soft delete flag
                _department.Update(department);
                var count = _department.Complet();

                if (count > 0)
                {
                    TempData["message"] = "Department Deleted Successfully";
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["message"] = "Delete Operation Failed";
                return View(department);
            }
        }
    }
}