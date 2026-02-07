using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.AdminDTOs;
using MongoDB_RestaurantProject.Services.AdminService;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _adminService.GetListAsync();
            var result = _mapper.Map<List<ResultAdminDTO>>(list);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminDTO createAdminDTO)
        {
            var entity = _mapper.Map<Context.Entities.Admin>(createAdminDTO);
            await _adminService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminDTO updateAdminDTO)
        {
            var entity = _mapper.Map<Context.Entities.Admin>(updateAdminDTO);
            await _adminService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAdmin(string id)
        {
            await _adminService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
