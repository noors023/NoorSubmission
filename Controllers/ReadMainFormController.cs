using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoorSubmission.Models;
using System.Data.Entity;


namespace NoorSubmission.Controllers
{ 
    public class ReadMainFormController : Controller
    {
        //TODO: You should never inject a controller into your Frontend. If you need to talk to an API you should use HttpClient. This needs to be deleted.
        private readonly MainFormModelsAPIController Apicontroller;

        public ReadMainFormController(MainFormModelsAPIController Apicontroller2)
        {
            Apicontroller = Apicontroller2;
        }

        public async Task<IActionResult> Index()
        {
            //TODO: You should never call a controller action. Use HttpClient to consume an API. 
            var forms = await Apicontroller.GetForms();
            return View(forms);
        }

        public async Task<IActionResult> Delete()
        {
            //TODO: You should never call a controller action. Use HttpClient to consume an API. 
            await Apicontroller.DeleteAllData();
            var forms = await Apicontroller.GetForms();
            return View("Index" , forms );
        }
    }
}
