using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoorSubmission.Models;
using System.Data.Entity;

namespace NoorSubmission.Controllers
{ 
    public class ReadMainFormController : Controller
    {
        private readonly MainFormModelsAPIController Apicontroller;

        public ReadMainFormController(MainFormModelsAPIController Apicontroller2)
        {
            Apicontroller = Apicontroller2;
        }

        public async Task<IActionResult> Index()
        {
            var forms = await Apicontroller.GetForms();
            return View(forms);
        }

        public async Task<IActionResult> Delete()
        {

            await Apicontroller.DeleteAllData();
            var forms = await Apicontroller.GetForms();
            return View("Index" , forms );
        }
    }
}
