using FastReport;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoorSubmission.API.Models;
using NoorSubmission.Models;

namespace NoorSubmission.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissonController : ControllerBase
    {

        private readonly AppDbContext _context;

        public SubmissonController(AppDbContext context)
          => _context = context;

        [HttpPost]
        public async Task<ActionResult<List<MainFormModel>>> PostMainFormModel(MainFormModel mainFormModel)
        {
            if (_context.Forms == null)
            {
                return Problem("Entity set 'AppDbContext.Forms'  is null.");
            }
            _context.Forms.Add(mainFormModel);
            await _context.SaveChangesAsync();
            var forms = await _context.Forms.ToListAsync();

            return forms;
        }

        // Delete all data from the database
        [HttpDelete]
        public async Task<ActionResult<List<MainFormModel>>> DeleteAllData()
        {
            try
            {

                _context.Forms.RemoveRange(_context.Forms);
                await _context.SaveChangesAsync();
                var updatedForms = await _context.Forms.ToListAsync();

                return updatedForms;
            }

            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<List<MainFormModel>> GetForms()
        {

            var forms = _context.Forms.ToList();

            return forms;
        }

        [HttpGet("download")]
        public async Task<FileResult> ExportReport()
        {
            var forms = await GetForms();
            Report report = new Report();
            report.Load("FormsReport.frx");
            report.RegisterData(forms, "Forms");
            report.Report.Prepare();
            using MemoryStream ms = new MemoryStream();
            PDFSimpleExport pdfExport = new PDFSimpleExport();
            report.Report.Export(pdfExport, ms);
            ms.Flush();
            var pdf = ms.ToArray();
            return File(pdf, "application/pdf", "myReport.pdf");
        }
    }
}
