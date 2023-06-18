using Microsoft.AspNetCore.Mvc;
using NoorSubmission.Models;

namespace NoorSubmission.Controllers
{
    public class MainFormController : Controller
    {

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
            if (FormInputs["Fname1"].Count > 0 && !FormInputs["Fname1"].Equals("") && !FormInputs["Nationality1"].Equals("Select Nationality") && !FormInputs["Nationality1"].Equals(""))
            {
                //Write into DB 
                MainFormModel Form = new MainFormModel();
                Form.Fname = FormInputs["Fname1"];
                Form.Lname = FormInputs["Lname1"];
                Form.Age = FormInputs["Age1"];
                Form.Nationality = FormInputs["Nationality1"]; 
                await Apicontroller.PostMainFormModel(Form); 

            }
            return View("MainFormIndex");
        }
 


       


    }
}
