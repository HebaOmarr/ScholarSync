using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScholarSyncMVC.Models;
using ScholarSyncMVC.Repository.Contract;
using ScholarSyncMVC.ViewModels;

namespace ScholarSyncMVC.Controllers
{
    public class ScholarshipController : Controller
    {
        private readonly IScholarship _scholarship;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<University> _university;
        private readonly IGenericRepository<Country> _country;
        private readonly IGenericRepository<Department> _department;
        private readonly IGenericRepository<Category> _category;

        public ScholarshipController(IScholarship scholarship , IMapper mapper,
            IGenericRepository<University> university, IGenericRepository<Country> country
            ,IGenericRepository<Department> department , IGenericRepository<Category> category)
        {
            _scholarship = scholarship;
            _mapper = mapper;
            _university = university;
            _country = country;
            _department = department;
            _category = category;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _scholarship.GetAllWithTables();
            if (list == null)
            { return NotFound(); }
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _scholarship.GetByIdInclude(id);
            if (item == null) return RedirectToAction(nameof(Index));
            var itemMapped = _mapper.Map<Scholarship, ScholarshipVM>(item);
            return View(itemMapped);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var UniList = await _university.GetAll();
            var CatList = await _category.GetAll();
            var CouList = await _country.GetAll();
            var DepList = await _department.GetAll();
            ScholarshipVM scholarshipVM = new ScholarshipVM()
            {
                Categories = CatList,
                Universities = UniList,
                Countries = CouList,
                Departments = DepList
            };
            return View(scholarshipVM);
        }

        // POST: University/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ScholarshipVM scholarshipVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var schMapped = _mapper.Map<ScholarshipVM, Scholarship>(scholarshipVM);
                    _scholarship.Add(schMapped);
                    var count = _scholarship.Complet();

                    if (count > 0)
                    {
                        TempData["message"] = "Scholarship Added Successfully";
                    }
                    else
                    {
                        TempData["message"] = "Failed Add Operation";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException?.Message ?? ex.Message);
                }
            }

            return View(scholarshipVM);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var UniList = await _university.GetAll();
            var CatList = await _category.GetAll();
            var CouList = await _country.GetAll();
            var DepList = await _department.GetAll();
            var item = await _scholarship.GetByIdInclude(id);
            if (item == null) return RedirectToAction(nameof(Index));
            var itemMapped = _mapper.Map<Scholarship, ScholarshipVM>(item);
            itemMapped.Categories = CatList;
            itemMapped.Countries = CouList;
            itemMapped.Universities = UniList;
            itemMapped.Departments = DepList;
            return View(itemMapped);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScholarshipVM scholarshipVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var schMapped = _mapper.Map<ScholarshipVM, Scholarship>(scholarshipVM);
                    _scholarship.Update(schMapped);
                    var count = _scholarship.Complet();

                    if (count > 0)
                    {
                        TempData["message"] = "Scholarship Updated Successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException?.Message ?? ex.Message);
                }
            }

            return View(scholarshipVM);
        }


        public async Task<IActionResult> Delete(int id)
        {
			var item = await _scholarship.GetByIdInclude(id);
			if (item == null) return RedirectToAction(nameof(Index));
			var itemMapped = _mapper.Map<Scholarship, ScholarshipVM>(item);
			return View(itemMapped);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id ,ScholarshipVM scholarshipVM)
        {
			try
			{
				var scholarship = _mapper.Map<ScholarshipVM, Scholarship>(scholarshipVM);
				scholarship.IsDeleted = true; // Assuming you have a soft delete flag
				_scholarship.Update(scholarship);
				var count = _scholarship.Complet();

				if (count > 0)
				{
					TempData["message"] = "Scholarship Deleted Successfully";
				}

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				TempData["message"] = "Delete Operation Failed";
				return View(scholarshipVM);
			}
		}

    }
}
