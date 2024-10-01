using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScholarSyncMVC.Helper;
using ScholarSyncMVC.Models;
using ScholarSyncMVC.Repository.Contract;
using ScholarSyncMVC.ViewModels;

namespace ScholarSyncMVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly IGenericRepository<Country> _country;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CountryController(IGenericRepository<Country> country, IMapper mapper,
            IWebHostEnvironment environment)
        {
            _country = country;
            _mapper = mapper;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _country.GetAll();
            if (list == null)
            { return NotFound(); }
            return View(list);
        }
        public async Task<IActionResult> Details(int id)
        {
            var item = await _country.GetAsync(id);
            if (item == null) return RedirectToAction(nameof(Index));
            var itemMapped = _mapper.Map<Country, CountryVM>(item);
            return View(itemMapped);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Create New Category --post  Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryVM countryVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    countryVM.PhotoURL = countryVM.PhotoFile?.FileName;

                    if (countryVM.PhotoFile != null)
                    {
                        countryVM.PhotoURL = DocumentSetting.UploadFile(countryVM.PhotoFile, "country");
                    }
                    else
                    {
                        ModelState.AddModelError("PhotoURL", "Please Enter Photo");
                    }
                    var CouMapped = _mapper.Map<CountryVM, Country>(countryVM);
                    CouMapped.FilePath = Path.Combine(_environment.ContentRootPath, "wwwroot\\Uploads\\country", CouMapped.PhotoURL);

                    _country.Add(CouMapped);
                    var count = _country.Complet();

                    if (count > 0)
                        TempData["message"] = "Country Added Successfully";
                    else
                        TempData["message"] = "Failed Add Operation";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }

            return View(countryVM);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _country.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var itemMapped = _mapper.Map<Country, CounryEditVM>(item);
            return View(itemMapped);
        }

        //Edit category --post Category/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CounryEditVM counryVM)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (counryVM.PhotoFile != null)
                    {
                        if (System.IO.File.Exists(counryVM.FilePath))
                        {
                            System.IO.File.Delete(counryVM.FilePath);
                        }
                        counryVM.PhotoURL = DocumentSetting.UploadFile(counryVM.PhotoFile, "country");
                    }
                    var couMapped = _mapper.Map<CounryEditVM, Country>(counryVM);
                    couMapped.FilePath = Path.Combine(_environment.ContentRootPath, "wwwroot\\Uploads\\country", couMapped.PhotoURL);
                    _country.Update(couMapped);
                    var count = _country.Complet();
                    if (count > 0)
                    {
                        TempData["Message"] = $"Country Updated Successfully";
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.InnerException.Message);
                }
            }
            return View(counryVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id);
        }

        //Delete category --post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, CountryVM countryVM)
        {
            try
            {
                var country = _mapper.Map<CountryVM, Country>(countryVM);
                if (System.IO.File.Exists(country.FilePath))
                {
                    System.IO.File.Delete(country.FilePath);
                }
                country.IsDeleted = true;
                _country.Update(country);
                var count = _country.Complet();
                if (count > 0)
                {

                    TempData["Message"] = "Category Deleted Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Message"] = "Delete Operation Failed";
                return View(countryVM);
            }
        }
    }
}