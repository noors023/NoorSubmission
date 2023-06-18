using Microsoft.AspNetCore.Mvc;
using NoorSubmission.Models;

namespace NoorSubmission.Controllers
{
    public class MainFormController : Controller
    {
        //TODO: You should never inject a controller into your Frontend. If you need to talk to an API you should use HttpClient. This needs to be deleted.
        private readonly MainFormModelsAPIController Apicontroller;

        public MainFormController(MainFormModelsAPIController Apicontroller2)
        {
            Apicontroller = Apicontroller2;
        }

        public IActionResult MainFormIndex()
        {  
            return View();
        }

        public async Task<IActionResult> AddForm(IFormCollection FormInputs)
        {
            //TODO: Business should move to API. Only call the API and send object as a request.
            if (FormInputs["Fname1"].Count > 0 && !FormInputs["Fname1"].Equals("") && !FormInputs["Nationality1"].Equals("Select Nationality") && !FormInputs["Nationality1"].Equals(""))
            {
                //Write into DB 
                MainFormModel Form = new MainFormModel();
                Form.Fname = FormInputs["Fname1"];
                Form.Lname = FormInputs["Lname1"];
                Form.Age = FormInputs["Age1"];
                Form.Nationality = FormInputs["Nationality1"];
                //TODO: You should never call a controller action. Use HttpClient to consume an API. 
                await Apicontroller.PostMainFormModel(Form); 

            }
            return View("MainFormIndex");
        }
    }
}
