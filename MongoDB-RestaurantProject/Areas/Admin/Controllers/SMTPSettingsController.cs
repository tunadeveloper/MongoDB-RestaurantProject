using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.SmtpDTOs;
using MongoDB_RestaurantProject.Services.SMTPService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SMTPSettingsController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public SMTPSettingsController(IMailService mailService, IMapper mapper)
        {
            _mailService = mailService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CreateSMTP()
        {
            var list = await _mailService.GetListAsync();
            if (list != null && list.Count > 0)
                return RedirectToAction("UpdateSMTP");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSMTP(CreateSmtpDTO createSmtpDTO)
        {
            var entity = _mapper.Map<SmtpSettings>(createSmtpDTO);
            await _mailService.CreateAsync(entity);
            return RedirectToAction("UpdateSMTP");
        }

        public async Task<IActionResult> UpdateSMTP()
        {
            var list = await _mailService.GetListAsync();
            if (list == null || list.Count == 0)
                return RedirectToAction("CreateSMTP");

            var first = list.FirstOrDefault();
            return View(first);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSMTP(UpdateSmtpDTO updateSmtpDTO)
        {
            var entity = _mapper.Map<SmtpSettings>(updateSmtpDTO);
            await _mailService.UpdateAsync(entity);
            return RedirectToAction("UpdateSMTP");
        }
    }
}
