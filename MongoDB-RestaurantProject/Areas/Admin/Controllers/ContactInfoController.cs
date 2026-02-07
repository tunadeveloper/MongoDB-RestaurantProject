using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.ContactInfoDTOs;
using MongoDB_RestaurantProject.Services.ContactInfoService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService _contactInfoService;
        private readonly IMapper _mapper;
        public ContactInfoController(IContactInfoService contactInfoService, IMapper mapper)
        {
            _contactInfoService = contactInfoService;
            _mapper = mapper;
        }
        public IActionResult CreateContactInfo() => View();
        [HttpPost]
        public async Task<IActionResult> CreateContactInfo(CreateContactInfoDTO createContactInfoDTO)
        {
            var entity = _mapper.Map<ContactInfo>(createContactInfoDTO);
            await _contactInfoService.CreateAsync(entity);
            return RedirectToAction("UpdateContactInfo");
        }
        
        public async Task<IActionResult> UpdateContactInfo()
        {
            var list = await _contactInfoService.GetListAsync();
            if (list == null || list.Count == 0)
                return RedirectToAction("CreateContactInfo");

            var first = list.FirstOrDefault();
            var entity = _mapper.Map<UpdateContactInfoDTO>(first);
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo(UpdateContactInfoDTO updateContactInfoDTO)
        {
            var entity = _mapper.Map<ContactInfo>(updateContactInfoDTO);
            await _contactInfoService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }

    }
}
