using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using desafio_barigui.Models;

namespace desafio_barigui.Controllers {
  #region CostumerController

  [Route("api/[controller]")]
  [ApiController]
  public class CostumerItemsController : ControllerBase {
    private readonly CostumerContext _context;

    public CostumerItemsController(CostumerContext context) {
      _context = context;
    }

    #endregion

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CostumerItem>>> GetCostumerItems() {
      return await _context.CostumerItems.ToListAsync();
    }

    #region snippet_GetByID

    [HttpGet("{id}")]
    public async Task<ActionResult<CostumerItem>> GetCostumerItem(long id) {
      var costumerItem = await _context.CostumerItems.FindAsync(id);

      if (costumerItem == null) {
        return NotFound();
      }

      return costumerItem;
    }

    #endregion

    #region snippet_Update

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCostumerItem(long id, CostumerItem costumerItem) {
      if (id != costumerItem.Id) {
        return BadRequest();
      }

      _context.Entry(costumerItem).State = EntityState.Modified;

      try {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException) {
        if (!CostumerItemExists(id)) {
          return NotFound();
        }

        throw;
      }

      return NoContent();
    }

    #endregion

    #region snippet_Create

    [HttpPost]
    public async Task<ActionResult<CostumerItem>> PostCostumerItem(CostumerItem costumerItem) {
      await _context.CostumerItems.AddAsync(costumerItem);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCostumerItem),
        new {id = costumerItem.Id}, costumerItem);
    }

    #endregion

    #region snippet_Delete

    [HttpDelete("{id}")]
    public async Task<ActionResult<CostumerItem>> DeleteCostumerItem(long id) {
      var costumerItem = await _context.CostumerItems.FindAsync(id);
      if (costumerItem == null) {
        return NotFound();
      }

      _context.CostumerItems.Remove(costumerItem);
      await _context.SaveChangesAsync();

      return costumerItem;
    }

    #endregion

    private bool CostumerItemExists(long id) {
      return _context.CostumerItems.Any(e => e.Id == id);
    }
  }
}
