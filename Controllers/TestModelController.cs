using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FVA.Database;
using FVA.Database.Models;

namespace FVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestModelController(OdinDatabaseContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestModel>>> GetTestModels()
        {
            return await context.TestModels.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TestModel>> GetTestModel(int id)
        {
            var testModel = await context.TestModels.FindAsync(id);

            if (testModel == null)
            {
                return NotFound();
            }

            return testModel;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTestModel(int id, TestModel testModel)
        {
            if (id != testModel.TestId)
            {
                return BadRequest();
            }

            context.Entry(testModel).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestModelExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TestModel>> PostTestModel(TestModel testModel)
        {
            context.TestModels.Add(testModel);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTestModel", new { id = testModel.TestId }, testModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTestModel(int id)
        {
            var testModel = await context.TestModels.FindAsync(id);
            if (testModel == null)
            {
                return NotFound();
            }

            context.TestModels.Remove(testModel);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestModelExists(int id)
        {
            return context.TestModels.Any(e => e.TestId == id);
        }
    }
}
