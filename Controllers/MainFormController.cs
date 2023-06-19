using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using NoorSubmission.Models;
using Newtonsoft.Json;
using System.Text;

namespace NoorSubmission.Controllers
{
    public class MainFormController : Controller
    {
       
        public IActionResult MainFormIndex()
        {  
            return View();
        }

        public async Task<IActionResult> AddForm(IFormCollection FormInputs)
      
        {

            using var httpClient = new HttpClient();
            {
               
                if (FormInputs["Fname1"].Count > 0 && !FormInputs["Fname1"].Equals("") && !FormInputs["Nationality1"].Equals("Select Nationality") && !FormInputs["Nationality1"].Equals(""))
                {
                    //Write into DB 
                    MainFormDto Form = new MainFormDto();
                    Form.Fname = FormInputs["Fname1"];
                    Form.Lname = FormInputs["Lname1"];
                    Form.Age = FormInputs["Age1"];
                    Form.Nationality = FormInputs["Nationality1"];

                    // Serialize the form to JSON
                    string jsonData = JsonConvert.SerializeObject(Form);

                    // Create StringContent with the serialized JSON
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var url = "http://localhost:5183/api/Submisson";
                      var response = await httpClient.PostAsync(url, content);
                      if (response.IsSuccessStatusCode)
                      {
                          var contentinserted = await response.Content.ReadAsAsync<List<MainFormDto>>();
                        // Handle the content
                        return View("MainFormIndex");
                    }
                      else
                      {
                          // Handle the error case
                          return View("Error");
                      }

                }
                return View("MainFormIndex");
            }
        }
    }
}
