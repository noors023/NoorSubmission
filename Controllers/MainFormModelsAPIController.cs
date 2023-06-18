using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoorSubmission.Models;

namespace NoorSubmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainFormModelsAPIController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MainFormModelsAPIController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MainFormModelsAPI
        [HttpGet]
        public async Task<List<MainFormModel>> GetForms()
        {
           
            return await _context.Forms.ToListAsync();
        }

        // GET: api/MainFormModelsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainFormModel>> GetMainFormModel(int id)
        {
          if (_context.Forms == null)
          {
              return NotFound();
          }
            var mainFormModel = await _context.Forms.FindAsync(id);

            if (mainFormModel == null)
            {
                return NotFound();
            }

            return mainFormModel;
        }

        // PUT: api/MainFormModelsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainFormModel(int id, MainFormModel mainFormModel)
        {
            if (id != mainFormModel.MainFormModelId)
            {
                return BadRequest();
            }

            _context.Entry(mainFormModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainFormModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MainFormModelsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MainFormModel>> PostMainFormModel(MainFormModel mainFormModel)
        {
          if (_context.Forms == null)
          {
              return Problem("Entity set 'AppDbContext.Forms'  is null.");
          }
            _context.Forms.Add(mainFormModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainFormModel", new { id = mainFormModel.MainFormModelId }, mainFormModel);
        }
        //Delete all Data 
        [HttpDelete]
        public async Task<IActionResult> DeleteAllData()
        {
            try
            {
                // Delete all data from the database
                _context.Forms.RemoveRange(_context.Forms);
                await _context.SaveChangesAsync();

                return Ok("All data deleted successfully.");
            }

            catch (Exception ex)
            {
                // Handle any exceptions that occur during the deletion process
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        // DELETE: api/MainFormModelsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainFormModel(int id)
        {
            if (_context.Forms == null)
            {
                return NotFound();
            }
            var mainFormModel = await _context.Forms.FindAsync(id);
            if (mainFormModel == null)
            {
                return NotFound();
            }

            _context.Forms.Remove(mainFormModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MainFormModelExists(int id)
        {
            return (_context.Forms?.Any(e => e.MainFormModelId == id)).GetValueOrDefault();
        }
    }
}
